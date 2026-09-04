using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.Services;
using Game.Scripts.CubeMechanics.Services.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Game.Scripts.CubeMechanics.Controllers
{
    public class GameCubeController : MonoBehaviour, IStartable, IGameCubeController
    {
        private ICubeDataGetterService _cubeDataGetterService;
        private IDataLoader _dataLoader;
        
        private CubeColorData _cubeData;
        
        public void Start()
        {
            Init();
        }

        private async void Init()
        {
            InitServices();
            await InitData();
        }

        private void InitServices()
        {
            _dataLoader = new DataLoader();
            _cubeDataGetterService = new CubeDataGetterService(_dataLoader);
        }

        private async UniTask InitData()
        {
            _cubeData = await _cubeDataGetterService.LoadRawDataAsync();
        }
    }
}
