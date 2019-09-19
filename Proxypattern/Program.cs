using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxypattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogProxy proxy = new BlogProxy();
            Console.WriteLine("Enter password to enter this blog");
            proxy.authenticate(Console.ReadLine());
            Console.ReadLine();
        }
    }

    public interface IBlog
    {
        void addPost(string post);
        List<string> getBlogPosts();
    }

    public class BlogProxy : IBlog
    {
        private RealBlog _realBlog;
        private string _password;

        public BlogProxy()
        {
            Console.WriteLine("Proxy instantiated");
            _password = "donderdag";
        }

        public bool authenticate(string password)
        {
            if(password == _password)
            {
                Console.WriteLine("Password correct!");
                _realBlog = new RealBlog();
                return true;
            } else
            {
                Console.WriteLine("Password incorrect try again...");
                return false;
            }
        }

        public void addPost(string post)
        {
            if(_realBlog == null)
            {
                return;
            }
            _realBlog.addPost(post);
        }

        public List<string> getBlogPosts()
        {
            if (_realBlog == null)
            {
                return null;
            } 
            return _realBlog.getBlogPosts();
        }
    }

    public class RealBlog : IBlog
    {
        private List<String> _blogPosts;
        private bool _isAuthenticated;

        public RealBlog()
        {
            _isAuthenticated = false;
            Console.WriteLine("RealBlog instantiated");
        }

        public void getBlog()
        {
            if (_isAuthenticated)
            {
                Console.WriteLine("First blog, yaay!");
            } else
            {
                Console.WriteLine("Not authenticated");
            }
        }

        public void addPost(string post)
        {
            if (post != null)
            {
                this._blogPosts.Add(post);
            }
        }

        public List<string> getBlogPosts()
        {
            if(this._blogPosts != null)
            {
                return this._blogPosts;
            } else
            {
                return new List<string>();
            }
        }
    }
}
