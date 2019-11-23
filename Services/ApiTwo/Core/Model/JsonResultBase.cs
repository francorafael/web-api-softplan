using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApiTwo.Application.Base
{
    [ExcludeFromCodeCoverage]
    public class JsonResultBase<TResult> 
        where TResult : class
    {
        public TResult Data { get; set; }
        public bool Error { get; set; }
        public IEnumerable<ValidationMessageBase> Messages { get; set; }

    }
}
