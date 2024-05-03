using System.ComponentModel.DataAnnotations;

namespace Chat_Online.DTO
{
    public class UtenteDto
    {
        [StringLength(250)]
        public string? Cod { get; set; }

        [Required]
        [StringLength(250)]

        public string Use { get; set; } = null!;

        [Required]
        [StringLength(250)]
        public string Pas { get; set; } = null!;

        public bool? IsDel { get; set; }
    }
}
