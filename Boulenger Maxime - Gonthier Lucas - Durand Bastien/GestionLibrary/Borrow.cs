namespace GestionLibrary;

/// <summary>
/// Class pour la gestion des emprunts
/// </summary>
public class Borrow
{
    public string User { get; set; }
    public Media Media { get; set; }
    public DateTime BorrowDate { get; set; }
    
    /// <summary>
    /// Constructeur de la class Borrow (emprunt)
    /// </summary>
    /// <param name="p_user"></param>
    /// <param name="p_media"></param>
    public Borrow(string p_user, Media p_media)
    {
        User = p_user;
        Media = p_media;
        BorrowDate = DateTime.Now;
    }
}