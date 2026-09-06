namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface ICubeColorData
    {
        public int[][] Matrix { get; }
        public int Width { get; }
        public int Height { get; }
    }
}