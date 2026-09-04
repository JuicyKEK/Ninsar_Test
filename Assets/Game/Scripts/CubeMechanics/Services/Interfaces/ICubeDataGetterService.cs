using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;

namespace Game.Scripts.CubeMechanics.Services
{
    public interface ICubeDataGetterService
    {
        public UniTask<CubeColorData> LoadRawDataAsync();
    }
}