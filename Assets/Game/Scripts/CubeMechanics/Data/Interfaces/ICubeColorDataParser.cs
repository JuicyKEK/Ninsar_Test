using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Data
{
    public interface ICubeColorDataParser
    {
        public CubeColorData ParseTextToMatrix(string fileText);
    }
}