using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class MessageMap:BaseMap<Message>
    {
        public MessageMap()
        {
            HasKey(x=>x.ID);
            Property(x => x.Subject).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(x => x.Content).HasColumnType("nvarchar").HasMaxLength(2000).IsRequired();
            Property(x => x.Sender).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(x => x.Receiver).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}
