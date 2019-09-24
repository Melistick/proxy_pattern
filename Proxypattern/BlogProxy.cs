using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        authenticate();
    }

    private void authenticate()
    {
        Print("Enter password to enter this blog");
        while (!_isAuthenticated)
        {
            if (Console.ReadLine() == _password)
            {
                Print("Password correct!");
                _realBlog = new RealBlog();
                _isAuthenticated = true;
            }
            else
            {
                Print("Password incorrect try again...");
            }
        }
    }

    public void update()
    {
        Print("So what's your next step? Type 'p' to add a new post, 'r' to read all your saved posts or 'q' to quit.");
        string currentCommand = Console.ReadLine().ToLower();
        doAction(currentCommand);
    }

    public void doAction(string command)
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

    public void AddPost(string post)
    {
        if (_realBlog == null)
        {
            return;
        }
        _realBlog.AddPost(post);
    }

    public void PrintBlogPosts()
    {
        if (_realBlog == null)
        {
            return;
        }
        _realBlog.PrintBlogPosts();
    }

    public void Print(string p)
    {
        string dateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        Console.WriteLine(dateTime + ": " + p);
    }
}