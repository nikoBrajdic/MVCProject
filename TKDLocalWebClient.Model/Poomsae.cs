using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKDLocalWebClient.Model
{
    public class Poomsae
    {
        [Key]
        public int ID { get; set; }
        [Required, RegularExpression(@"^[\w\- ]+$")]
        public string Name { get; set; }
        [Required, RegularExpression(@"^[\w\-]+$")]
        public string ShortName { get; set; }
        [Required, RegularExpression(@"^\d{1,2}$")]
        public string Ordinal { get; set; }


        [ForeignKey(nameof(PoomsaeType))]
        public int PoomsaeTypeId { get; set; }
        public PoomsaeType PoomsaeType { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [InverseProperty(nameof(Category.Poomsae11))]
        public virtual ICollection<Category> Poomsae11s { get; set; }

        [InverseProperty(nameof(Category.Poomsae12))]
        public virtual ICollection<Category> Poomsae12s { get; set; }

        [InverseProperty(nameof(Category.Poomsae21))]
        public virtual ICollection<Category> Poomsae21s { get; set; }

        [InverseProperty(nameof(Category.Poomsae22))]
        public virtual ICollection<Category> Poomsae22s { get; set; }

        [InverseProperty(nameof(Category.Poomsae31))]
        public virtual ICollection<Category> Poomsae31s { get; set; }

        [InverseProperty(nameof(Category.Poomsae32))]
        public virtual ICollection<Category> Poomsae32s { get; set; }
    }
}
