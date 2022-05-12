using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public interface IResult
    {
        public bool Success { get; set; }
        
        public string Message { get; set; }
    }
}
