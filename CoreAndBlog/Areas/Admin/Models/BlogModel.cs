using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndBlog.Areas.Admin.Models
{
    public class BlogModel
    {
        [Key]
        public int Id { get; set; }
        public string BlogName { get; set; }
    }
}
