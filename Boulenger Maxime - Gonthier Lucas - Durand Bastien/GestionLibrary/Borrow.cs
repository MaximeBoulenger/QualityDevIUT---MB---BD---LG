namespace GestionLibrary;

public class Borrow
{
    public string User { get; set; }
    public Media Media { get; set; }
    public DateTime BorrowDate { get; set; }

    public Borrow(string user, Media media)
    {
        User = user;
        Media = media;
        BorrowDate = DateTime.Now;
    }
}