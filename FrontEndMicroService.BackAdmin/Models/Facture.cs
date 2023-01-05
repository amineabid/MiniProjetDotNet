using System.ComponentModel.DataAnnotations;

namespace FrontEndMicroService.BackAdmin.Models
{
    public class Facture
    {
        [Key]
        public int Id { get; set; }
        public Intervention? Intervention { get; set; }
        public int? InterventionId { get; set; }
        public List<LigneFacture> LigneFactures { get; set; }
    }
}
