using Game.Scripts.CubeMechanics.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Services
{
    public class MatrixBuilder : IMatrixBuilder
    {
        private readonly CubeColorData _cubeColorData;
        
        public MatrixBuilder(CubeColorData cubeColorData)
        {
            _cubeColorData = cubeColorData;
        }
        
        public int[][] BuildMatrix(int centerRow, int centerCol, int height, int width)
        {
            int halfHeight = height / 2;
            int halfWidth = width / 2;

            var window = new int[height][];

            for (int i = 0; i < height; i++)
            {
                window[i] = new int[width];

                int sourceRow = Mathf.Clamp(centerRow + (i - halfHeight), 0, _cubeColorData.Height - 1);

                for (int j = 0; j < width; j++)
                {
                    int sourceCol = Mathf.Clamp(centerCol + (j - halfWidth), 0, _cubeColorData.Width - 1);
                    window[i][j] = _cubeColorData.Matrix[sourceRow][sourceCol];
                }
            }

            return window;
        }
    }
}