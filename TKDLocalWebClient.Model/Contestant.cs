using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKDLocalWebClient.Model
{
    public class Contestant
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
