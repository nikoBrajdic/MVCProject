using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKDLocalWebClient.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, RegularExpression(@"^[\w\-]+$")]
        public string ShortName { get; set; }
        [Required]
        public bool IsFreestyle { get; set; }
        public int? CurrentRound { get; set; }


        [ForeignKey(nameof(Poomsae11))]
        public int Poomsae11ID { get; set; }
        public virtual Poomsae Poomsae11 { get; set; }

        [ForeignKey(nameof(Poomsae12))]
        public int Poomsae12ID { get; set; }
        public virtual Poomsae Poomsae12 { get; set; }

        [ForeignKey(nameof(Poomsae21))]
        public int Poomsae21ID { get; set; }
        public virtual Poomsae Poomsae21 { get; set; }

        [ForeignKey(nameof(Poomsae22))]
        public int Poomsae22ID { get; set; }
        public virtual Poomsae Poomsae22 { get; set; }

        [ForeignKey(nameof(Poomsae31))]
        public int Poomsae31ID { get; set; }
        public virtual Poomsae Poomsae31 { get; set; }

        [ForeignKey(nameof(Poomsae32))]
        public int Poomsae32ID { get; set; }
        public virtual Poomsae Poomsae32 { get; set; }

        public virtual ICollection<Contestant> Contestants { get; set; }
    }
}
