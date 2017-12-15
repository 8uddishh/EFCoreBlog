using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
