using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ezytask.utilities
{
    public static class ExtensionMethods
    {
        public static T CastByExample<T>(this object obj, T example)
        {
            return (T)obj;
        }
    }
}
