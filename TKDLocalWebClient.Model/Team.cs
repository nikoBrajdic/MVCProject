using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TKDLocalWebClient.Model
{
    public class Team
    {
        [Key]
        public int ID { get; set; }
        [Required, RegularExpression(@"^[\w\- ]+$", ErrorMessage = "Name must only contain letters, numbers, whitespaces, -, and _")]
        public string Name { get; set; }

        public virtual ICollection<Contestant> Contestants { get; set; }
    }
}
