using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.Services;
using Game.Scripts.InputController;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.CubeMechanics.Controllers
{
    public class GameCubeController : MonoBehaviour, IStartable, IGameCubeController
    {
        private const int MatrixSize = 3;

        private readonly ReplaySubject<MatrixData> _colorMatrix = new(1);
        private readonly CompositeDisposable _disposables = new();
        public Observable<MatrixData> ColorMatrix => _colorMatrix;

        private ICubeColorDataParser _cubeColorDataParser;
        private ICubeDataGetterService _cubeDataGetter;
        private IMatrixCreateService _matrixCreater;
        private IMatrixBuilder _matrixBuilder;
        private IMatrixMover _matrixMover;

        private ICubeInputController _cubeInputController;
        private IDataLoader _dataLoader;

        private ICubeColorData _cubeData;
        private MatrixData _currentMatrix;

        [Inject]
        public void Construct(ICubeInputController cubeInputController, IDataLoader dataLoader)
        {
            _cubeInputController = cubeInputController;
            _dataLoader = dataLoader;
        }

        public void Start()
        {
            Init();
        }

        private async UniTaskVoid Init()
        {
            await LoadingData();
            InitServices();
            InitColorMatrix();
        }

        private async UniTask LoadingData()
        {
            _cubeColorDataParser = new CubeColorDataParser();
            _cubeDataGetter = new CubeDataGetterService(_dataLoader, _cubeColorDataParser);
            _cubeData = await _cubeDataGetter.LoadRawDataAsync();
        }

        private void InitServices()
        {
            if (_cubeData == null)
            {
                throw new ArgumentNullException($"Данные цветов не удалось загрузить");
            }
            
            _matrixBuilder = new MatrixBuilder(_cubeData);
            _matrixCreater = new MatrixCreateService(_cubeData, _matrixBuilder);
            _matrixMover = new MatrixMover(_matrixBuilder);

            _cubeInputController.KeyPressed
                .Subscribe(Move)
                .AddTo(_disposables);
        }

        private void InitColorMatrix()
        {
            _currentMatrix = _matrixCreater.CreateMatrixFromRandom(MatrixSize, MatrixSize);
            _colorMatrix.OnNext(_currentMatrix);
        }

        private void Move(KeyCode keyCode)
        {
            if (_currentMatrix == null)
            {
                return;
            }

            _matrixMover.MatrixMove(keyCode, _currentMatrix);
            _colorMatrix.OnNext(_currentMatrix);
        }

        private void OnDestroy()
        {
            _colorMatrix.Dispose();
            _disposables.Dispose();
        }
    }
}
