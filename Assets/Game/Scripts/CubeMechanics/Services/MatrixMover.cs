
using System.Collections.Generic;
using Game.Scripts.CubeMechanics.Data;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Services
{
    public class MatrixMover : IMatrixMover
    {
        private readonly IMatrixBuilder _matrixBuilder;
        private readonly Dictionary<KeyCode, Vector2Int> _moveOffsets = new()
        {
            { KeyCode.W, new Vector2Int(-1, 0) },
            { KeyCode.S, new Vector2Int(1, 0) },
            { KeyCode.A, new Vector2Int(0, -1) },
            { KeyCode.D, new Vector2Int(0, 1) },
        };
        
        public MatrixMover(IMatrixBuilder matrixBuilder)
        {
            _matrixBuilder = matrixBuilder;
        }

        public void MatrixMove(KeyCode key, MatrixData matrix)
        {
            var offset = SelectMoveOffset(key);
            matrix.StartPosition += offset;
            _matrixBuilder.Fill(matrix.Matrix, matrix.StartPosition.x,
                matrix.StartPosition.y);
        }

        private Vector2Int SelectMoveOffset(KeyCode key)
        {
            return _moveOffsets.GetValueOrDefault(key, Vector2Int.zero);
        }
    }
}