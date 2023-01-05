using System.ComponentModel.DataAnnotations;

namespace FacturesApi.Models
{
    public class LigneFacture
    {
        [Key]
        public int id { get; set; }
        public Facture? Facture { get; set; }
        public int? FactureId { get; set; }
        public int Qte { get; set; }
        public Piece? Piece { get; set; }
        public int? PieceId { get; set; }
        public double Prix { get; set; }
    }
}
