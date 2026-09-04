using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.Services;
using Game.Scripts.CubeMechanics.Services.Interfaces;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.CubeMechanics.Controllers
{
    public class GameCubeController : MonoBehaviour, IStartable, IGameCubeController
    {
        private const int MatrixSize = 3;
        
        private readonly ReactiveProperty<int[][]> _colorMatrix = new();
        public ReadOnlyReactiveProperty<int[][]> ColorMatrix => _colorMatrix;
        
        private ICubeDataGetterService _cubeDataGetter;
        private IMatrixCreateService _matrixCreateService;
        private IMatrixBuilder _matrixBuilder;
        private IDataLoader _dataLoader;
        
        private CubeColorData _cubeData;
        
        [Inject]
        public void Construct(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }
        
        public void Start()
        {
            Init();
        }

        private async void Init()
        {
            await InitData();
            InitServices();
            InitColorMatrix();
        }

        private void InitServices()
        {
            _matrixBuilder = new MatrixBuilder(_cubeData); 
            _matrixCreateService = new MatrixCreateService(_cubeData, _matrixBuilder);
        }

        private async UniTask InitData()
        {
            _cubeDataGetter = new CubeDataGetterService(_dataLoader);
            _cubeData = await _cubeDataGetter.LoadRawDataAsync();
        }

        private void InitColorMatrix()
        {
            _colorMatrix.Value = _matrixCreateService.GetMatrixFromRandom(MatrixSize, MatrixSize);
        }
    }
}
