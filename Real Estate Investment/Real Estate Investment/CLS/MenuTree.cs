using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateInvestment.CLS
{
    public class MenuTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public string flagUrl { get; set; }
        public string population { get; set; }
        public bool @checked { get; set; }
        public List< MenuTree> nodes { get; set; }
        public int? MainMenu { get; set; }
        public string Icon { get; set; }
        public MenuTree()
        {
            nodes = new List<MenuTree>();
        }
    }
}
