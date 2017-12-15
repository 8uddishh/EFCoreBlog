using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class BlogTag
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
