using Game.Scripts.CubeMechanics.Data;

namespace Game.Scripts.CubeMechanics.Services
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
            int sourceHeight = _cubeColorData.Matrix.Length;
            int sourceWidth = _cubeColorData.Matrix[0].Length;

            for (int i = 0; i < matrix.Length; i++)
            {
                int sourceRow = ((centerRow + i) % sourceHeight + sourceHeight) % sourceHeight;

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int sourceCol = ((centerCol + j) % sourceWidth + sourceWidth) % sourceWidth;
                    matrix[i][j] = _cubeColorData.Matrix[sourceRow][sourceCol];
                }
            }
        }
    }
}