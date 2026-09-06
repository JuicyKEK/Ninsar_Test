using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.View
{
    public class CubeListView : MonoBehaviour
    {
        [SerializeField] private CubeView[] _cubeViews;

        public void Init()
        {
            for (int i = 0; i < _cubeViews.Length; i++)
            {
                _cubeViews[i].Init();
            }
        }
        
        public void SetColor(Color[] colors)
        {
            if (colors.Length != _cubeViews.Length)
            {
                Debug.LogError($"Количество цветов - {colors.Length} не совпадает с количеством кубов - {_cubeViews.Length}");
            }
            
            for (int i = 0; i < _cubeViews.Length; i++)
            {
                _cubeViews[i].SetColor(colors[i]);
            }
        }
    }
}