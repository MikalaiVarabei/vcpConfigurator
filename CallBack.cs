﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scm
{
    class CallBack
    {
        public delegate void callbackEvent(char[] dataReceiv, int length);
        public static callbackEvent callbackEventHandler;
    }
}
