using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //get sadece okunabilir Read Only!
        bool Success { get; }
        string Message { get; }
    }
}
