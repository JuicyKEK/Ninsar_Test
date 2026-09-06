using Game.Scripts.CubeMechanics.Controllers.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.Data
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

        public MatrixData CreateMatrixFromRandom(int height, int width)
        {
            if (height > _cubeColorData.Height || width > _cubeColorData.Width)
            {
                Debug.LogError(
                    $"Запрошенный участок {width}x{height} больше исходной матрицы {_cubeColorData.Width}x{_cubeColorData.Height}.");
                return null;
            }

            Vector2Int startPos = new Vector2Int(Random.Range(0, _cubeColorData.Height), 
                Random.Range(0, _cubeColorData.Width));

            return new MatrixData(_matrixBuilder.BuildMatrix(startPos.x, startPos.y, height, width),
                height, width, startPos);
        }
    }
}