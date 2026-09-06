namespace Game.Scripts.CubeMechanics.Data
{
    public class GameCubeSettingsData : IGameCubeSettingsData
    {
        public string AddressablesCoubeColorDataPath => _addressablesDataPath;
        public int MatrixSize => _matrixSize;
        
        private readonly string _addressablesDataPath = "CubeСolors";
        private readonly int _matrixSize = 3;
    }
}