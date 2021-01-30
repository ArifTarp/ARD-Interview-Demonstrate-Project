using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        int HttpStatusCode { get; set; }
    }
}
