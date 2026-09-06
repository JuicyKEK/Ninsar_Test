namespace Game.Scripts.CubeMechanics.Data
{
    public class CubeColorData : ICubeColorData
    {
        public int[][] Matrix => _matrix;
        public int Width => _width;
        public int Height => _height;
        
        private readonly int[][] _matrix;
        private readonly int _width;
        private readonly int _height;
        
        public CubeColorData(int width, int height, int[][] matrix)
        {
            _width = width;
            _height = height;
            _matrix = matrix;
        }
    }
}