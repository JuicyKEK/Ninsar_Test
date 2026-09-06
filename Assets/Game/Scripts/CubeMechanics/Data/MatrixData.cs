using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public class MatrixData
    {
        public int[][] Matrix => _matrix;
        public int Height => _height;
        public int Width => _width;
        public Vector2Int StartPosition;

        private int[][] _matrix;
        private int _height;
        private int _width;
        
        public MatrixData(int[][] matrix, int height, int width, Vector2Int startPosition)
        {
            _height = height;
            _width = width;

            _matrix = matrix;
            StartPosition = startPosition;
        }
    }
}