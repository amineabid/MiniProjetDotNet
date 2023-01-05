using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FactureCreated
    {
        public string action { get; set; }
        public int Id { get; set; }
        public int? InterventionId { get; set; }
    }
}
