using Game.Scripts.CubeMechanics.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Services
{
    public interface IMatrixMover
    {
        public void MatrixMove(KeyCode key, MatrixData matrix);
    }
}