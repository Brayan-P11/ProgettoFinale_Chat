using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Chat_Online.DTO
{
    public class StanzaDto
    {
        [Required]
        [StringLength(100)]
        public string CodS { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(500)]
        public string? Desc { get; set; }

        //[Required]
        public List<string>? Utentes { get; set; }

        //[Required]
        public List<ObjectId>? MessaID { get; set; }

        //[Required]
        public List<MessaggioDto>? Messa { get; set; }
    }
}
