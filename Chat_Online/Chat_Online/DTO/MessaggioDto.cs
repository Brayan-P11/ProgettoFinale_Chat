using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Chat_Online.DTO
{
    public class MessaggioDto
    {
        [Required]
        [StringLength(100)]
        public string? Codi { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string? NomU { get; set; }

        [Required]
        [StringLength(500)]
        public string? Cont { get; set; }

        [Required]
        [StringLength(100)]
        public ObjectId? Stan { get; set; }

        [Required]
        public DateTime Orar { get; set; }
    }
}
