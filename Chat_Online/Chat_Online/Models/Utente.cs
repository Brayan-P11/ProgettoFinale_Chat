namespace Chat_Online.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string? Codice { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordU { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
