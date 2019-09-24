using System;
using System.Collections.Generic;
using System.Threading;

namespace ProxyPattern_2
{
    public class RealBlog : IBlog
    {
        private List<string> _blogPosts;

        public RealBlog()
        {
            _blogPosts = new List<string>();
            Print("RealBlog instantiated...");
        }

        public void AddPost(string post)
        {
            if (post != null)
            {
                _blogPosts.Add(post);
                Print("Blogpost '" + post + "' is succesfully added to your blog.");
            }
        }

        public void PrintBlogPosts()
        {
            if (_blogPosts != null)
            {
                Print("Your blogposts will be printed now...");
                foreach (string item in _blogPosts)
                {
                    Print(item);
                    Thread.Sleep(500);
                }
                Print("--- END ---");
            }
        }

        public void Print(string p)
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            Console.WriteLine(dateTime + ": " + p);
        }
    }
}