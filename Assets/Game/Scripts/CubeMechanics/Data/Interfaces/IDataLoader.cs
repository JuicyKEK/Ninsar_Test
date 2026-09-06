using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Data
{
    public interface IDataLoader
    {
        public UniTask<string> LoadRawDataAsync(string filePath);
    }
}