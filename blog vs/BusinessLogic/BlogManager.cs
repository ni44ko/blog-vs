using blogvs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogvs.Repository
{
    public class BlogManager : IBlogManager
    {
        private readonly BlogDBContext _blogDBContext;

        public BlogManager(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public List<Post> GetPosts()
        {
            List<Post> post_lists = (from postObject in _blogDBContext.Posts
                                     select new Post()
                                     {
                                         Id = postObject.Id,
                                         Title = postObject.Title,
                                         DatePublished = postObject.DatePublished,
                                         Content = postObject.Content,
                                         Intro = postObject.Intro,
                                         Category = postObject.Category

                                     }).ToList(); ;
            return post_lists;
        }

        public bool SaveBlog(Post newPost)
        {
            bool result = true;
            var post = new Post()
            {
                Title = newPost.Title,
                DatePublished = newPost.DatePublished,
                Content = newPost.Content,
                Intro = newPost.Content,
                Category = newPost.Category
            };

            try
            {
                _blogDBContext.Posts.Add(post);
                _blogDBContext.SaveChanges();
            }catch(Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}
