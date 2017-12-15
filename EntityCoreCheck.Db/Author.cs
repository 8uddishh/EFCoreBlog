using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
