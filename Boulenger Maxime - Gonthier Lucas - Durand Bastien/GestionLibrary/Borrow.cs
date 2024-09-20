namespace GestionLibrary;

// Class pour la gestion des emprunts
public class Borrow
{
    public string User { get; set; }
    public Media Media { get; set; }
    public DateTime BorrowDate { get; set; }

    // Constructeur de la class Borrow (emprunt)
    public Borrow(string user, Media media)
    {
        User = user;
        Media = media;
        BorrowDate = DateTime.Now;
    }
}