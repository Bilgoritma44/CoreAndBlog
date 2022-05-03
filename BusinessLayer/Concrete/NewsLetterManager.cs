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
    public class NewsLetterManager : INewsLetterService
    {

        INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetter = newsLetterDal;
        }

        public void MailAdd(NewsLetter newsLetter)
        {
            _newsLetter.Add(newsLetter);
        }
    }
}
