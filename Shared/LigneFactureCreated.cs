using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class LigneFactureCreated
    {
        public string action { get; set; }
        public int id { get; set; }
        public int? FactureId { get; set; }
        public int Qte { get; set; }
        public int? PieceId { get; set; }
        public double Prix { get; set; }
    }
}
