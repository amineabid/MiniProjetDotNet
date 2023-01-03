using System.ComponentModel.DataAnnotations;

namespace FrontEndMicroService.BackAdmin.Models
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int  ArticleId { get; set; }
    }
}