namespace ProxyPattern_2
{
    public interface IBlog
    {
        void AddPost(string post);
        string GetBlogPosts();
        void PrintBlogPosts();
    }
}