using Cysharp.Threading.Tasks;
using Game.Scripts.InputController;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using System.Collections.Generic;
using Game.Scripts.CubeMechanics.Controllers.Data;

namespace Game.Scripts.CubeMechanics.Controllers.Controllers
{
    public class GameCubeController : MonoBehaviour, IStartable, IGameCubeController
    {
        private const int MatrixSize = 3;

        private readonly ReactiveProperty<MatrixData> _colorMatrix = new();
        private readonly CompositeDisposable _disposables = new();
        public ReadOnlyReactiveProperty<MatrixData> ColorMatrix => _colorMatrix;
        
        private ICubeDataGetterService _cubeDataGetter;
        private IMatrixCreateService _matrixCreater;
        private IMatrixBuilder _matrixBuilder;
        private IMatrixMover _matrixMover;
        
        private ICubeInputController _cubeInputController;
        private IDataLoader _dataLoader;
        
        private CubeColorData _cubeData;
        
        [Inject]
        public void Construct(IDataLoader dataLoader, ICubeInputController cubeInputController)
        {
            _dataLoader = dataLoader;
            _cubeInputController = cubeInputController;
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
            if (_cubeData == null)
            {
                Debug.LogError($"Не удалось загрузить данные");
                return;
            }
            
            _matrixBuilder = new MatrixBuilder(_cubeData); 
            
            _matrixCreater = new MatrixCreateService(_cubeData, _matrixBuilder);
            _matrixMover = new MatrixMover(_matrixBuilder);
            
            _cubeInputController.KeyPressed
                .Subscribe(Move)
                .AddTo(_disposables);
        }

        private async UniTask InitData()
        {
            _cubeDataGetter = new CubeDataGetterService(_dataLoader);
            _cubeData = await _cubeDataGetter.LoadRawDataAsync();
        }

        private void InitColorMatrix()
        {
            if (_cubeData == null)
            {
                Debug.LogError($"Не удалось загрузить данные");
                return;
            }
            
            _colorMatrix.Value = _matrixCreater.CreateMatrixFromRandom(MatrixSize, MatrixSize);
        }

        private void Move(KeyCode keyCode)
        {
            if (_colorMatrix.Value == null)
            {
                return;
            }
                
            _matrixMover.MatrixMove(keyCode, _colorMatrix.Value);
            _colorMatrix.ForceNotify();
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        } 
    }
}
