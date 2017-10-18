
namespace web.api.entities
{
    using System;
    using System.Collections.Generic;

    public class UseLess
    {
        public int UseLessId { get; set; }
        public string UseLessName { get; set; }
        public string UseLessDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UselessHref { get; set; }
        public IEnumerable<Bogus> BogusCollection { get; set; }
    }
}
