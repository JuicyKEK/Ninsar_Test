namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface IMatrixBuilder
    {
        public int[][] BuildMatrix(int centerRow, int centerCol, int height, int width);
        public void Fill(int[][] matrix, int centerRow, int centerCol);
    }
}