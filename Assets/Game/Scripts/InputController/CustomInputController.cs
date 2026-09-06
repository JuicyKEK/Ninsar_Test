using R3;
using UnityEngine;

namespace Game.Scripts.InputController
{
    public class CustomInputController : MonoBehaviour, ICubeInputController
    {
        public Observable<KeyCode> KeyPressed => _keyPressed;
        
        private readonly Subject<KeyCode> _keyPressed = new();
        private readonly KeyCode[] _trackedKeys =
        {
            KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D
        };
        
        private void Update()
        {
            for (int i = 0; i < _trackedKeys.Length; i++)
            {
                if (Input.GetKeyDown(_trackedKeys[i]))
                {
                    _keyPressed.OnNext(_trackedKeys[i]);
                }
            }
        }

        private void OnDestroy()
        {
            _keyPressed.Dispose();
        } 
    }
}