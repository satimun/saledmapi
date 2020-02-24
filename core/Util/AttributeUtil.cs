﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Util
{
    public static class AttributeUtil
    {
        public static T GetAttributeOfType<T>(object property) where T : System.Attribute
        {
            var type = property.GetType();
            var memInfo = type.GetMember(property.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
