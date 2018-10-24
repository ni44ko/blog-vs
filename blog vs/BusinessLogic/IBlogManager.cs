using blogvs.Models;
using System.Collections.Generic;

namespace blogvs.Repository
{
    public interface IBlogManager
    {
        List<Post> GetPosts();
        bool SavePost(Post post);
        List<Post> GetLatestPosts();
        List<Category> GetCategories();
    }
}