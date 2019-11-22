using System.Collections.Generic;

namespace ApiTwo.Application.Base
{
    public class JsonResultBaseViewModel<TResult> 
        where TResult : class
    {
        public TResult Data { get; set; }
        public bool Error { get; set; }
        public IEnumerable<ValidationMessageBase> Messages { get; set; }

    }
}
