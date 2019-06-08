using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TKDLocalWebClient.Model
{
    public class PoomsaeType
    {
        [Required]
        public int ID { get; set; }
        [Required, RegularExpression(@"^[\w\- ]+$", ErrorMessage = "Name must only contain letters, numbers, whitespaces, -, and _")]
        public string Name { get; set; }

        public virtual ICollection<Poomsae> Poomsaes { get; set; }
    }
}
