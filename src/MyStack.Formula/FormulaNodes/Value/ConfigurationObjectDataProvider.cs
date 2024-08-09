using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStack.Formula.FormulaNodes.Value
{
    public class ConfigurationObjectDataProvider : IObjectDataProvider
    {
        public ConfigurationObjectDataProvider(
            IOptionsMonitor<FormulaParserOptions> options)
        {
            Items = options.CurrentValue.Items;
        }
        protected List<ObjectData>? Items { get; }
        public Task<string> GetValueAsync(string id)
        {
            var value = Items?.Find(x => x.Id == id)?.Value;
            if (value == null)
                return Task.FromResult("0");
            return Task.FromResult(value);
        }
    }
}
