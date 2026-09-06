using UnityEngine;

namespace Game.Scripts.CubeMechanics.Data
{
    public class MatrixData
    {
        public int[][] Matrix => _matrix;
        public int Height => _height;
        public int Width => _width;
        public Vector2Int StartPosition;

        private readonly int[][] _matrix;
        private readonly int _height;
        private readonly int _width;

        public MatrixData(int[][] matrix, int height, int width, Vector2Int startPosition)
        {
            _height = height;
            _width = width;

            _matrix = matrix;
            StartPosition = startPosition;
        }
    }
}