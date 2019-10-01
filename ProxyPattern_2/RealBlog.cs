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
            Format("RealBlog instantiated...");
        }

        public void AddPost(string post)
        {
            if (post != null)
            {
                _blogPosts.Add(post);
                Format("Blogpost '" + post + "' is succesfully added to your blog.");
            }
        }

        public string GetBlogPosts()
        {
            if (_blogPosts != null)
            {
                string output = Format("--- START --- \r\n");
                foreach (string item in _blogPosts)
                {
                    output += Format(item);
                    output += "\r\n";
                    Thread.Sleep(500);
                }
                output += Format("--- END ---");
                return output;
            }

            return Format("There are nog BlogPosts yet!");
        }

        public void PrintBlogPosts()
        {
            if (_blogPosts != null)
            {
                Console.WriteLine("Your blogposts will be printed now...");
                Console.WriteLine(GetBlogPosts());
            }
        }

        public string Format(string p)
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            return dateTime + ": " + p;
        }

    }
}