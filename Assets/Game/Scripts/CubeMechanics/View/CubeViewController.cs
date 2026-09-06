using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.View;
using R3;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CubeMechanics.Controllers.View
{
    public class CubeViewController : MonoBehaviour, ICubeViewController
    {
        private readonly CompositeDisposable _disposables = new();
        
        [SerializeField] private CubeListView _cubeListView;
        [SerializeField] private Color[] _colors;
        
        private IGameCubeController _gameCubeController;

        [Inject]
        private void Construct(IGameCubeController gameCubeController)
        {
            _gameCubeController = gameCubeController;
            _cubeListView.Init();
            
            _gameCubeController.ColorMatrix
                .Where(matrix => matrix != null)
                .Subscribe(OnColorMatrixChanged)
                .AddTo(_disposables);
        }
        
        private void OnColorMatrixChanged(MatrixData matrix)
        {
            if (matrix == null) 
            {
                return;
            }
            
            if (matrix.Matrix.Length == 0 || matrix.Matrix[0].Length == 0)
            {
                Debug.LogError($"Размерность матрицы по высоте - {matrix.Matrix.Length}, по ширине - {matrix.Matrix[0].Length}");
                return;
            }
            
            Color[] colors = CreateColorArray(matrix.Matrix);
            _cubeListView.SetColor(colors);
        }

        private Color[] CreateColorArray(int[][] matrix)
        {
            Color[] colors = new Color[matrix.Length * matrix[0].Length];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int symbol = matrix[i][j] - 1;

                    if (symbol >= _colors.Length)
                    {
                        Debug.LogError($"Символ {symbol} выходит за диапазон созданных цветов");
                        symbol = 0;
                    }
                    
                    colors[index] = _colors[symbol];
                    index++;
                }
            }
            
            return colors;
        }
    }
}