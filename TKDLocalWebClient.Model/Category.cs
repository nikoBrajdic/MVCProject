using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TKDLocalWebClient.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public int? Poomsae1ID { get; set; }
        public Poomsae Poomsae1 { get; set; }

        public int? Poomsae2ID { get; set; }
        public Poomsae Poomsae2 { get; set; }

        public int? Poomsae3ID { get; set; }
        public Poomsae Poomsae3 { get; set; }

        public virtual ICollection<Contestant> Contestants { get; set; }
    }
}
