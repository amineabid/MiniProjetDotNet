using System.ComponentModel.DataAnnotations;

namespace ArticleApi.Models
{
    public class Piece
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public int ArticleId { get; set; }
    }
}
