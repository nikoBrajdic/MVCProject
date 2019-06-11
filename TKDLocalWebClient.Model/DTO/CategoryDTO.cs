using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TKDLocalWebClient.Model.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsFreestyle { get; set; }
        public PoomsaeDTO Poomsae11 { get; set; }
        public PoomsaeDTO Poomsae12 { get; set; }
        public PoomsaeDTO Poomsae21 { get; set; }
        public PoomsaeDTO Poomsae22 { get; set; }
        public PoomsaeDTO Poomsae31 { get; set; }
        public PoomsaeDTO Poomsae32 { get; set; }

        public static Expression<Func<Category, CategoryDTO>> SelectorExpression { get; } = p => new CategoryDTO()
        {
            ID = p.ID,
            Name = p.Name,
            ShortName = p.ShortName,
            IsFreestyle = p.IsFreestyle,
            Poomsae11 = p.Poomsae11ID == null ? null : new PoomsaeDTO()
            {
                ID = p.Poomsae11.ID,
                Name = p.Poomsae11.Name,
                Ordinal = p.Poomsae11.Ordinal,
                ShortName = p.Poomsae11.ShortName,
                PoomsaeType = new PoomsaeTypeDTO()
                {
                    ID = p.Poomsae11.PoomsaeType.ID,
                    Name = p.Poomsae11.PoomsaeType.Name
                }
            }
        };
    }
}
