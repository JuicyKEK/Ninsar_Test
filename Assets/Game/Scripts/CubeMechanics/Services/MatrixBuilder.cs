using Game.Scripts.CubeMechanics.Controllers.Data;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public class MatrixBuilder : IMatrixBuilder
    {
        private readonly ICubeColorData _cubeColorData;
        
        public MatrixBuilder(ICubeColorData cubeColorData)
        {
            _cubeColorData = cubeColorData;
        }
        
        public int[][] BuildMatrix(int centerRow, int centerCol, int height, int width)
        {
            var matrix = new int[height][];

            for (int i = 0; i < height; i++)
            {
                matrix[i] = new int[width];
            }
            
            Fill(matrix, centerRow, centerCol);
            
            return matrix;
        }
        
        public void Fill(int[][] matrix, int centerRow, int centerCol)
        {
            int matrixHeight = matrix.Length;
            int matrixWidth = matrix[0].Length;
            int sourceHeight = _cubeColorData.Matrix.Length;
            int sourceWidth = _cubeColorData.Matrix[0].Length;

            for (int i = 0; i < matrixHeight; i++)
            {
                int sourceRow = ((centerRow + i) % sourceHeight + sourceHeight) % sourceHeight;

                for (int j = 0; j < matrixWidth; j++)
                {
                    int sourceCol = ((centerCol + j) % sourceWidth + sourceWidth) % sourceWidth;
                    matrix[i][j] = _cubeColorData.Matrix[sourceRow][sourceCol];
                }
            }
        }
    }
}