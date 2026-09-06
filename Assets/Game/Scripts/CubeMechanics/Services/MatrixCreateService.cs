using System;
using Game.Scripts.CubeMechanics.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Services
{
    public class MatrixCreateService : IMatrixCreateService
    {
        private readonly ICubeColorData _cubeColorData;
        private readonly IMatrixBuilder _matrixBuilder;

        public MatrixCreateService(ICubeColorData cubeColorData, IMatrixBuilder matrixBuilder)
        {
            _cubeColorData = cubeColorData;
            _matrixBuilder = matrixBuilder;
        }

        public MatrixData CreateMatrixFromRandom(int height, int width)
        {
            if (height > _cubeColorData.Height || width > _cubeColorData.Width)
            {
                throw new ArgumentOutOfRangeException(
                    $"Запрошенный участок {width}x{height} больше исходной матрицы {_cubeColorData.Width}x{_cubeColorData.Height}.");
            }
            
            Vector2Int startPos = new Vector2Int(UnityEngine.Random.Range(0, _cubeColorData.Height),
                UnityEngine.Random.Range(0, _cubeColorData.Width));

            return new MatrixData(_matrixBuilder.BuildMatrix(startPos.x, startPos.y, height, width),
                height, width, startPos);
        }
    }
}