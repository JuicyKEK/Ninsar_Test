using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Controllers.Data;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface ICubeDataGetterService
    {
        public UniTask<CubeColorData> LoadRawDataAsync();
    }
}