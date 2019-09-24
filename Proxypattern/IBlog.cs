using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public interface IBlog
{
    void AddPost(string post);
    void PrintBlogPosts();
}