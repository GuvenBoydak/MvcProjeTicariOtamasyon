using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class SalesMovementMap:BaseMap<SalesMovement>
    {
        public SalesMovementMap()
        {
            HasKey(x=>x.ID);

        }
    }
}
