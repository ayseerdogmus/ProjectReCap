using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {  

        public Result(bool success, string message):this(success)
        {
            //proplar sadece get olduğu için read only fakat constructorda set edilebilir.
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}
