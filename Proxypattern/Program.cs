﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxypattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogProxy proxy = new BlogProxy();
            while (proxy.isRunning)
            {
                proxy.update();
            }
        }
    }
}

