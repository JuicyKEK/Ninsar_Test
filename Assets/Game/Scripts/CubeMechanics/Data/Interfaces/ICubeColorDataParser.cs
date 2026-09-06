using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public interface ICubeColorDataParser
    {
        public CubeColorData ParseTextToMatrix(string fileText);
    }
}