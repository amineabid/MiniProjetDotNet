using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturesApi.Models
{
    public class Intervention
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool garantie { get; set; }
        public int? ReclamationId { get; set; }
        public Reclamation? Reclamation { get; set; }
    }
}
