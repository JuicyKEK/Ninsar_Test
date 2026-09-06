using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface IDataLoader
    {
        public UniTask<string> LoadRawDataAsync(string filePath);
    }
}