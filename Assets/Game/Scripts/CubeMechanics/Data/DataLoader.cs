using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Services.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Scripts.CubeMechanics.Services
{
    public class DataLoader : IDataLoader
    {
        public async UniTask<string> LoadRawDataAsync(string filePath)
        {
            var handle = Addressables.LoadAssetAsync<TextAsset>(filePath);
            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Failed to load {filePath}: {handle.OperationException}");
                return null;
            }

            string rawText = handle.Result.text;

            Addressables.Release(handle); 

            return rawText;
        }
    }
}