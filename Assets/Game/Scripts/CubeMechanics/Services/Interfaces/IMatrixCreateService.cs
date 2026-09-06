using Game.Scripts.CubeMechanics.Controllers.Data;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface IMatrixCreateService
    {
        public MatrixData CreateMatrixFromRandom(int height, int width);
    }
}