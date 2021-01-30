using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Utilities.Results
{
    public class SuccessfulResult : IResult
    {
        public int HttpStatusCode { get; set; }

        public SuccessfulResult(HttpStatusCode httpStatusCode)
        {
            this.HttpStatusCode = Convert.ToInt32(httpStatusCode);
        }
    }
}
