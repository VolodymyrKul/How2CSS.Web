using How2CSS.Services.Exceptions;
using How2CSS.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace How2CSS.Web.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
        {
            switch (exception)
            {
                case NotFoundException _:
                    return (HttpStatusCode.NotFound, ErrorCode.NotFound);
                case InvalidCredentialsException _:
                    return (HttpStatusCode.Unauthorized, ErrorCode.InvalidUsernameOrPassword);
                default:
                    return (HttpStatusCode.InternalServerError, ErrorCode.General);
            }
        }
    }
}
