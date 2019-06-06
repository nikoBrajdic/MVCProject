using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKDLocalWebClient.Model
{
    public enum PoomsaeType
    {
        Regular = 1,
        Freestyle = 1 << 1,
        FourDirections = 1 << 2
    }

    public class Poomsae
    {
        [Key]
        public int ID { get; set; }
        [Required, RegularExpression(@"^[\w ]$")]
        public string Name { get; set; }
        [Required, RegularExpression(@"^[\w]$")]
        public string ShortName { get; set; }
        [Required, RegularExpression(@"^\d{1,2}$")]
        public string Ordinal { get; set; }
        [Required, Column(TypeName = "varchar")]
        public PoomsaeType Type { get; set; }
        public string Path { get; set; }
    }
}
