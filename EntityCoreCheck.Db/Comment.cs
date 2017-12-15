using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string CommentInfo { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
