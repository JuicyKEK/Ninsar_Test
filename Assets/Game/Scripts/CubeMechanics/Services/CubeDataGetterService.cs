using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.Services.Interfaces;

namespace Game.Scripts.CubeMechanics.Services
{
    public class CubeDataGetterService : ICubeDataGetterService
    {
        private const string AddressablesDataPath = "CubeСolors";
        
        private readonly ICubeColorDataParser _cubeColorDataParser;
        private readonly IDataLoader _dataLoader;

        public CubeDataGetterService(IDataLoader dataLoader)
        {
            _cubeColorDataParser = new CubeColorDataParser();
            _dataLoader = dataLoader;
        }
        
        public async UniTask<CubeColorData> LoadRawDataAsync()
        {
            string fileText = await _dataLoader.LoadRawDataAsync(AddressablesDataPath);
            
            if (string.IsNullOrWhiteSpace(fileText))
            {
                throw new InvalidOperationException($"The file at the path {AddressablesDataPath} is empty or has not been loaded.");
            }
            
            return _cubeColorDataParser.ParseTextToMatrix(fileText);
        }
    }
}