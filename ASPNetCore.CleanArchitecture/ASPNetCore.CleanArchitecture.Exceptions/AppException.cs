/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;

namespace ASPNetCore.CleanArchitecture.Exceptions
{
    public class AppException : Exception
    {
        #region Constructor
        public AppException(ExceptionsCodes exceptionCode) : base(((int)exceptionCode).ToString()) { }
        #endregion
    }
}
