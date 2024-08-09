using System.Threading.Tasks;

namespace MyStack.FormulaParser.FormulaNodes.Value
{
    public interface IObjectDataProvider
    {
        Task<double> GetValueAsync(string id);
    }
}
