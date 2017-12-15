using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<BlogTag> BlogTags { get; set; }
    }
}
