using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.api.entities
{
    public class UseLess
    {
        public int UseLessId { get; set; }
        public string UseLessName { get; set; }
        public string UseLessDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UselessHref { get; set; }
    }
}
