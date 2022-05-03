using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazarın Adı ve Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            
        }
    }
}
