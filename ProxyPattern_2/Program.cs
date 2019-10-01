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
            //Open new blog
            BlogProxy proxy = new BlogProxy();

            //Start authentication
            while (proxy.GetIsAuthenticated() == false)
            {
                proxy.Print("Enter password to enter this blog");
                proxy.Authenticate(Console.ReadLine());
            }

            //Ask for input
            while (proxy.isRunning)
            {
                proxy.Update();
            }
        }
    }
}
