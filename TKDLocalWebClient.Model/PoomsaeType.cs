using System;
using System.Collections.Generic;
using System.Text;

namespace TKDLocalWebClient.Model
{
    public class PoomsaeType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Poomsae> Poomsaes { get; set; }
    }
}
