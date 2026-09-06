using R3;
using UnityEngine;

namespace Game.Scripts.InputController
{
    public interface ICubeInputController
    {
        public Observable<KeyCode> KeyPressed { get; }
    }
}