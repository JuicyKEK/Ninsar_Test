using System;
using Game.Scripts.CubeMechanics.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Services
{
    public class MatrixCreateService : IMatrixCreateService
    {
        private readonly CubeColorData _cubeColorData;
        private readonly IMatrixBuilder _matrixBuilder;
        
        public MatrixCreateService(CubeColorData cubeColorData, IMatrixBuilder matrixBuilder)
        {
            _cubeColorData = cubeColorData;
            _matrixBuilder = matrixBuilder;
        }

        public int[][] GetMatrixFromRandom(int height, int width)
        {
            if (height > _cubeColorData.Height || width > _cubeColorData.Width)
            {
                Debug.LogError(
                    $"Запрошенный участок {width}x{height} больше исходной матрицы {_cubeColorData.Width}x{_cubeColorData.Height}.");
                return null;
            }

            int centerRow = UnityEngine.Random.Range(0, _cubeColorData.Height);
            int centerCol = UnityEngine.Random.Range(0, _cubeColorData.Width);

            return _matrixBuilder.BuildMatrix(centerRow, centerCol, height, width);
        }
    }
}