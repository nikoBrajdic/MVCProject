using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TKDLocalWebClient.Model.DTO
{
    public class PoomsaeTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static Expression<Func<PoomsaeType, PoomsaeTypeDTO>> SelectorExpression { get; } = p => new PoomsaeTypeDTO()
        {
            ID = p.ID,
            Name = p.Name
        };
    }
}
