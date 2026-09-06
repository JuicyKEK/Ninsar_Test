using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Controllers.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.Data
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
                Debug.LogError($"The file at the path {AddressablesDataPath} is empty or has not been loaded.");
                return null;
            }
            
            return _cubeColorDataParser.ParseTextToMatrix(fileText);
        }
    }
}