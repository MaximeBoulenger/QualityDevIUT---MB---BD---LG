namespace GestionLibrary;

// Class pour la gestion de la librairie
public class Library
{
    private List<Media> mediaCollection = new List<Media>();
    private List<Borrow> borrows = new List<Borrow>();

    // Ajout d'un media
    public void AddMedia(Media media)
    {
        mediaCollection.Add(media);
    }

    // Suppression d'un media
    public bool RemoveMedia(string title)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.Title == title);
        if (media != null)
        {
            mediaCollection.Remove(media);
            return true;
        }
        return false;
    }

    // Emprunt d'un media
    public bool BorrowMedia(string title, string user)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.Title == title && m.AvailableCopies > 0);
        if (media != null)
        {
            media.NbAvailable--; // Decrease the available copies
            borrows.Add(new Borrow(user, media)); // Record the borrow
            return true;
        }
        return false;
    }

    // Retour d'un media
    public bool ReturnMedia(string title, string user)
    {
        Borrow borrow = borrows.FirstOrDefault(b => b.Media.Title == title && b.User == user);
        if (borrow != null)
        {
            borrow.Media.NbAvailable =borrow.Media.NbAvailable + 1; // Increase the available copies
            borrows.Remove(borrow); // Remove the borrow record
            return true;
        }
        return false;
    }

    // Rechercher un media avec son titre ou son auteur
    public List<Media> SearchMedia(string searchCriteria)
    {
        return mediaCollection.Where(m =>
            m.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
            (m is Livre && ((Livre)m).Author.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase))
        ).ToList();
    }

    // Lister les medias emprunte
    public List<Borrow> ListBorrowsByUser(string user)
    {
        return borrows.Where(b => b.User == user).ToList();
    }

    // Afficher les stats de la librairie
    public void DisplayStatistics()
    {
        int totalMedia = mediaCollection.Count;
        int totalAvailableCopies = mediaCollection.Sum(m => m.AvailableCopies);
        int totalBorrows = borrows.Count;

        Console.WriteLine($"Total media: {totalMedia}");
        Console.WriteLine($"Total available copies: {totalAvailableCopies}");
        Console.WriteLine($"Total borrows: {totalBorrows}");
    }
}