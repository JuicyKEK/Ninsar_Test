using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Services.Interfaces
{
    public interface IDataLoader
    {
        public UniTask<string> LoadRawDataAsync(string filePath);
    }
}