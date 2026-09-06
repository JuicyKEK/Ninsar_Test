using Game.Scripts.CubeMechanics.Controllers.Data;
using R3;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface IMatrixMover
    {
        public void MatrixMove(KeyCode key, MatrixData matrix);
    }
}