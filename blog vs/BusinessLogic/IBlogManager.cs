using blogvs.Models;
using System.Collections.Generic;

namespace blogvs.Repository
{
    public interface IBlogManager
    {
        List<Post> GetPosts();
        bool SaveBlog(Post post);
    }
}