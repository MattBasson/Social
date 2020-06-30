using System;
using System.Collections.Generic;
using System.Text;

namespace Social.Database.Domain.Comments
{
    public class Comment
    {
        public Guid CommentId  { get; set; }

        public string Sku { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }
        
    }
}
