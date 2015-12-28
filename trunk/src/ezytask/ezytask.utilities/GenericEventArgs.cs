﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ezytask.utilities
{
    public class GenericEventArgs<T> : EventArgs
    {
        private T _data;

        public GenericEventArgs(T data)
        {
            _data = data;
        }

        public T Data
        {
            get { return _data; }
        }
    }
}
