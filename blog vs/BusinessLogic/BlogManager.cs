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
                                         PostId = postObject.PostId,
                                         Title = postObject.Title,
                                         DatePublished = postObject.DatePublished,
                                         Content = postObject.Content,
                                         Intro = postObject.Intro,
                                         Category = postObject.Category

                                     }).ToList(); ;
            return post_lists;
        }

        public bool SavePost(Post newPost)
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

        public List<Post> GetLatestPosts()
        {
            List<Post> post_lists = (from p in _blogDBContext.Posts
                                     orderby p.DatePublished descending
                                     select new Post()
                                     {
                                        PostId = p.PostId,
                                        Title = p.Title
                                     }).Take(3).ToList();

            return post_lists;
        }

        public List<Category> GetCategories()
        {
            List<Category> post_categories = (from c in _blogDBContext.Categories
                                              orderby c.CategoryId ascending
                                              select new Category()
                                              {
                                                  CategoryId = c.CategoryId,
                                                  Name = c.Name
                                              }).ToList();
            return post_categories;
        }
    }
}
