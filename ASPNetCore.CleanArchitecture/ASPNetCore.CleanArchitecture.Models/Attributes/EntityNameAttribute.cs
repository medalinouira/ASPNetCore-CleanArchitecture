/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;

namespace ASPNetCore.CleanArchitecture.Models.Attributs
{
    public class EntityNameAttribute : Attribute
    {
        #region Fields
        private string _entityName;
        #endregion

        #region Constructor
        public EntityNameAttribute(string Entity)
        {
            _entityName = Entity;
        }
        #endregion

        #region Methods
        public string GetEntityName()
        {
            return _entityName;
        }
        #endregion
    }
}
