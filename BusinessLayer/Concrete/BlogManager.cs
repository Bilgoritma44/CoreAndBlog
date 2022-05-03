using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }  

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetList();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetList().Take(3).ToList();
        }

        public List<Blog> GetListBlogId(int id)
        {
            return _blogDal.GetListDetail(x => x.BlogId == id);
        }

        public List<Blog> GetListCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetListCategoryWriter(int id)
        {
            return _blogDal.GetListCategoryWriter(id);
        }

        public List<Blog> GetListWriter(int id)
        {
            return _blogDal.GetListDetail(x => x.WriterId == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Add(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
