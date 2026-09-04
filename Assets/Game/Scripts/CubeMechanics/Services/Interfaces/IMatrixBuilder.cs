namespace Game.Scripts.CubeMechanics.Services
{
    public interface IMatrixBuilder
    {
        public int[][] BuildMatrix(int centerRow, int centerCol, int height, int width);
    }
}