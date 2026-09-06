using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.View
{
    public class CubeView : MonoBehaviour
    {
        private readonly int ColorPropertyId = Shader.PropertyToID("_Color");

        private Renderer _renderer;
        private MaterialPropertyBlock _propertyBlock;

        public void Init()
        {
            _renderer = GetComponent<Renderer>();
            _propertyBlock = new MaterialPropertyBlock();
        }

        public void SetColor(Color color)
        {
            _renderer.GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetColor(ColorPropertyId, color);
            _renderer.SetPropertyBlock(_propertyBlock);
        }
    }
}