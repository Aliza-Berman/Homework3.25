using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework3._25__2_.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public string CommenterName { get; set; }
    }
}
