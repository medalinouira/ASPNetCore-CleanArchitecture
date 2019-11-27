/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Newtonsoft.Json;

namespace ASPNetCore.CleanArchitecture.Exceptions
{
    public class ExceptionDetails
    {
        #region Fields
        public int Code { get; set; }
        public string Message { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion
    }
}
