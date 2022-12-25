using System.ComponentModel.DataAnnotations;

namespace InterventionsApi.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool garantie { get; set; }
        public int ReclamationId { get; set; }
        public Reclamation Reclamation { get; set; }
    }
}
