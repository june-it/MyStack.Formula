using System.Threading.Tasks;

namespace MyStack.Formula.FormulaNodes.Value
{
    public interface IObjectDataProvider
    {
        Task<string> GetValueAsync(string id);
    }
}
