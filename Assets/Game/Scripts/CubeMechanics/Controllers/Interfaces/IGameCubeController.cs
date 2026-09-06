using Game.Scripts.CubeMechanics.Controllers.Data;
using R3;

namespace Game.Scripts.CubeMechanics.Controllers
{
    public interface IGameCubeController
    {
        public ReadOnlyReactiveProperty<MatrixData> ColorMatrix { get; }
    }
}