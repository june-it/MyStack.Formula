using System.Threading.Tasks;

namespace MyStack.FormulaParser.Numbers
{
    public interface IIdValueProvider
    {
        Task<double> GetValueAsync(string id);
    }
}
