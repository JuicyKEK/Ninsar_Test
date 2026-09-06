using Game.Scripts.CubeMechanics.Data;
using R3;

namespace Game.Scripts.CubeMechanics.Controllers
{
    public interface IGameCubeController
    {
        public Observable<MatrixData> ColorMatrix { get; }
    }
}