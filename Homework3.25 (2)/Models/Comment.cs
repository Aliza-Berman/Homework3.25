using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework3._25__2_.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name {get;set;}
        public string CommentContent { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int PostId { get; set; }
    }
}
