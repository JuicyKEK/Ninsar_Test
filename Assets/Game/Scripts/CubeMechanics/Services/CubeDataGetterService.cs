using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;

namespace Game.Scripts.CubeMechanics.Services
{
    public class CubeDataGetterService : ICubeDataGetterService
    {
        private readonly IMatrixDataParser _cubeColorDataParser;
        private readonly IDataLoader _dataLoader;

        public CubeDataGetterService(IDataLoader dataLoader, IMatrixDataParser cubeColorDataParser)
        {
            _cubeColorDataParser = cubeColorDataParser;
            _dataLoader = dataLoader;
        }
        
        public async UniTask<int[][]> LoadRawDataAsync(string dataPath)
        {
            string fileText = await _dataLoader.LoadRawDataAsync(dataPath);
            
            if (string.IsNullOrWhiteSpace(fileText))
            {
                throw new ArgumentNullException(
                    $"Файл по пути {dataPath} пуст или не был загружен.");
            }

            return _cubeColorDataParser.ParseTextToMatrix(fileText);
        }
    }
}