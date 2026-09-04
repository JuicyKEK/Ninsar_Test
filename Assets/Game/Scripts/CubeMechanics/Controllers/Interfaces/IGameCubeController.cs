using Game.Scripts.CubeMechanics.Data;
using R3;

namespace Game.Scripts.CubeMechanics
{
    public interface IGameCubeController
    {
        public ReadOnlyReactiveProperty<int[][]> ColorMatrix { get; }
    }
}