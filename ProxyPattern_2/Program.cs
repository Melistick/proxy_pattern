using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern_2
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
