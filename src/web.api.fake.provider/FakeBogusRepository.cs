using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.entities;
using web.api.repositories;

namespace web.api.fake.provider
{
    class FakeBogusRepository :Repository<Bogus> , IBogusRepostitory
    {
        
    }
}
