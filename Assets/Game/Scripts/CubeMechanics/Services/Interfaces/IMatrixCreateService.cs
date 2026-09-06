using Game.Scripts.CubeMechanics.Data;

namespace Game.Scripts.CubeMechanics.Services
{
    public interface IMatrixCreateService
    {
        public MatrixData CreateMatrixFromRandom(int height, int width);
    }
}