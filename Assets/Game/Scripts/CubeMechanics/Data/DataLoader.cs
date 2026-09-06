using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Scripts.CubeMechanics.Data
{
    public class DataLoader : IDataLoader
    {
        public async UniTask<string> LoadRawDataAsync(string filePath)
        {
            var handle = Addressables.LoadAssetAsync<TextAsset>(filePath);
            await handle.ToUniTask();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                throw new InvalidOperationException( 
                    $"Не удалось загрузить '{filePath}': {handle.OperationException}");
            }

            string rawText = handle.Result.text;

            Addressables.Release(handle);

            return rawText;
        }
    }
}