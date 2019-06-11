using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKDLocalWebClient.Web.Models
{
    public class CategoryFilterModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsFreestyle { get; set; }
    }
}
