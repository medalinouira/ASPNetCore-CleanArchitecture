/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

namespace ASPNetCore.CleanArchitecture.Exceptions
{
    public enum ExceptionsCodes
    {
        #region Unknown
        UnknownCodeException = 50000,
        #endregion

        #region NotFound
        OrderNotFound = 40400,
        ProductNotFound = 40401,
        CustomerNotFound = 40402,
        #endregion

        #region Conflicts
        OrderConflict = 40900,
        ProductConflict = 40901,
        CustomerConflict = 40902,
        #endregion

        #region BadRequest
        OrderIdRequired = 40000,
        ProductIdRequired = 40001,
        CustomerIdRequired = 40002,
        #endregion
    }
}
