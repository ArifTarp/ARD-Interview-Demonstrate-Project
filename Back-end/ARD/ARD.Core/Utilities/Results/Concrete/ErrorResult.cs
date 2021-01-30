using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Utilities.Results
{
    public class ErrorResult : IResult
    {
        public int HttpStatusCode { get; set; }

        public ErrorResult(HttpStatusCode httpStatusCode)
        {
            this.HttpStatusCode = Convert.ToInt32(httpStatusCode);
        }
    }
}
