using System;

namespace ProxyPattern_2
{
    public class BlogProxy : IBlog
    {
        private RealBlog _realBlog;
        private string _password;
        private bool _isAuthenticated;
        public bool isRunning;

        public BlogProxy()
        {
            _password = "donderdag";
            _isAuthenticated = false;
            isRunning = true;
            Print("Proxy instantiated...");
        }
        
        //public GET
        public bool GetIsAuthenticated()
        {
            return _isAuthenticated;
        }

        //Instantiate _realBlog if the password is correct
        public bool Authenticate(string password)
        {
            if (!_isAuthenticated)
            {                
                if (password == _password)
                {
                    Print("Password correct!");
                    _realBlog = new RealBlog();
                    _isAuthenticated = true;
                    return true;
                }
                else
                {
                    Print("Password incorrect try again...");
                }
            }
            return false;
        }

        //Ask for input
        public void Update()
        {
            Print("So what's your next step? Type 'p' to add a new post, 'r' to read all your saved posts or 'q' to quit.");
            string currentCommand = Console.ReadLine().ToLower();
            DoAction(currentCommand);
        }

        //Process input
        public void DoAction(string command)
        {

            if (command == "p")
            {
                Print("Type in your blogtext here:");
                AddPost(Console.ReadLine());
                return;
            }
            if (command == "r")
            {
                PrintBlogPosts();
                return;
            }
            if (command == "q")
            {
                isRunning = false;
                return;
            }
        }

        //_realBlog is only instantiated when the password was correct
        public void AddPost(string post)
        {
            if (_realBlog == null)
            {
                return;
            }
            _realBlog.AddPost(post);
        }

        //Returns a formatted string with posts
        public string GetBlogPosts()
        {
            if (_realBlog == null)
            {
                return Format("There are nog BlogPosts yet!");
            }
            return _realBlog.GetBlogPosts();
        }

        //_realBlog is only instantiated when the password was correct
        public void PrintBlogPosts()
        {
            if (_realBlog == null)
            {
                return;
            }
            _realBlog.PrintBlogPosts();
        }
        
        //Format console output
        public string Format(string p)
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            return dateTime + ": " + p;
        }

        //Prints string
        public void Print(string p)
        {
            Console.WriteLine(Format(p));
        }

    }
}