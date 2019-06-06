using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfBridge.Entity.Entity
{
    public class DataFilledEntity
    {
        public bool Package { get; set; }
        public bool Personal { get; set; }
        public bool Academic { get; set; }
        public bool Licence { get; set; }
        public bool Work { get; set; }
        public bool Cogs { get; set; }
        public bool Logbook { get; set; }
        public bool LOA { get; set; }
    }
}
