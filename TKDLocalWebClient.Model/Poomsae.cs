using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TKDLocalWebClient.Model
{
    public class Poomsae
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ordinal { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
