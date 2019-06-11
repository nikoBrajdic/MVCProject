using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TKDLocalWebClient.Model.DTO
{
    public class PoomsaeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Ordinal { get; set; }
        public PoomsaeTypeDTO PoomsaeType { get; set; }

        public static Expression<Func<Poomsae, PoomsaeDTO>> SelectorExpression { get; } = p => new PoomsaeDTO()
        {
            ID = p.ID,
            Name = p.Name,
            ShortName = p.ShortName,
            Ordinal = p.Ordinal,
            PoomsaeType = new PoomsaeTypeDTO()
            {
                ID = p.PoomsaeType.ID,
                Name = p.PoomsaeType.Name
            }
        };

    }
}
