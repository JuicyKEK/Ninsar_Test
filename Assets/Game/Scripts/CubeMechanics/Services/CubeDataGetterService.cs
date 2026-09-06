using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;

namespace Game.Scripts.CubeMechanics.Services
{
    public class CubeDataGetterService : ICubeDataGetterService
    {
        private const string AddressablesDataPath = "CubeСolors";
        
        private readonly ICubeColorDataParser _cubeColorDataParser;
        private readonly IDataLoader _dataLoader;

        public CubeDataGetterService(IDataLoader dataLoader, ICubeColorDataParser cubeColorDataParser)
        {
            _cubeColorDataParser = cubeColorDataParser;
            _dataLoader = dataLoader;
        }
        
        public async UniTask<CubeColorData> LoadRawDataAsync()
        {
            string fileText = await _dataLoader.LoadRawDataAsync(AddressablesDataPath);
            
            if (string.IsNullOrWhiteSpace(fileText))
            {
                throw new ArgumentNullException(
                    $"Файл по пути {AddressablesDataPath} пуст или не был загружен.");
            }
            
            return _cubeColorDataParser.ParseTextToMatrix(fileText);
        }
    }
}