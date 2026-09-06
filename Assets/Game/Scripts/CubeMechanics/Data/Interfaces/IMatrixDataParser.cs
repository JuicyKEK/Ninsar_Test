using Cysharp.Threading.Tasks;

namespace Game.Scripts.CubeMechanics.Data
{
    public interface IMatrixDataParser
    {
        public int[][] ParseTextToMatrix(string fileText);
    }
}