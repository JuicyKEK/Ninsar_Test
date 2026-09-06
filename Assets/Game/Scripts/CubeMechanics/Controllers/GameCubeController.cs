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
        private readonly ReplaySubject<MatrixData> _colorMatrix = new(1);
        private readonly CompositeDisposable _disposables = new();
        public Observable<MatrixData> ColorMatrix => _colorMatrix;

        private IMatrixCreateService _matrixCreater;
        private IMatrixBuilder _matrixBuilder;
        private IMatrixMover _matrixMover;

        private IGameCubeSettingsData _gameCubeSettingsData;
        private ICubeInputController _cubeInputController;
        private ICubeDataGetterService _cubeDataGetter;

        private ICubeColorData _cubeData;
        private MatrixData _currentMatrix;

        [Inject]
        public void Construct(ICubeInputController cubeInputController,
            ICubeDataGetterService cubeDataGetter,
            IGameCubeSettingsData cubeSettingsData)
        {
            _cubeInputController = cubeInputController;
            _cubeDataGetter = cubeDataGetter;
            _gameCubeSettingsData = cubeSettingsData;
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
            var matrix = await _cubeDataGetter.LoadRawDataAsync(_gameCubeSettingsData.AddressablesCoubeColorDataPath);
            _cubeData = new CubeColorData(matrix[0].Length, matrix.Length, matrix);
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
            _currentMatrix = _matrixCreater.CreateMatrixFromRandom(_gameCubeSettingsData.MatrixSize,
                _gameCubeSettingsData.MatrixSize);
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
