using System.Text.Json;

namespace GestionLibrary;

public class Library
{
    private List<Media> mediaCollection = new List<Media>();
    private List<Borrow> borrows = new List<Borrow>();

    // 1. Add a Media
    public void AddMedia(Media media)
    {
        mediaCollection.Add(media);
    }

    // 2. Remove a Media
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

    // 3. Borrow a Media
    public bool BorrowMedia(string title, string user)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.Title == title && m.NbAvailable > 0);
        if (media != null)
        {
            media.NbAvailable--; // Decrease the available copies
            borrows.Add(new Borrow(user, media)); // Record the borrow
            return true;
        }
        return false;
    }

    // 4. Return a Media
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

    // 5. Search for Media by Title or Author
    public List<Media> SearchMedia(string searchCriteria)
    {
        return mediaCollection.Where(m =>
            m.Title.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
            (m is Livre && ((Livre)m).Author.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase))
        ).ToList();
    }

    // 6. List Media Borrowed by a User
    public List<Borrow> ListBorrowsByUser(string user)
    {
        return borrows.Where(b => b.User == user).ToList();
    }

    // 7. Display Library Statistics
    public void DisplayStatistics()
    {
        int totalMedia = mediaCollection.Count;
        int totalAvailableCopies = mediaCollection.Sum(m => m.AvailableCopies);
        int totalBorrows = borrows.Count;

        Console.WriteLine($"Total media: {totalMedia}");
        Console.WriteLine($"Total available copies: {totalAvailableCopies}");
        Console.WriteLine($"Total borrows: {totalBorrows}");
    }

    public void Save(string p_fileName = "data.json")
    {
        if (p_fileName != "data.json")
         if (!p_fileName.Contains(".json"))
        {
            p_fileName = p_fileName+".json";
        }
        
        var jsonString = JsonSerializer.Serialize(mediaCollection);
        File.WriteAllText(p_fileName, jsonString);
    }

    public void Import(string p_fileName = "data.json")
    {
        var dataFile = File.ReadAllText(p_fileName);
        var dataJsonAsList = JsonSerializer.Deserialize<List<Media>>(dataFile);
        mediaCollection.AddRange((IEnumerable<Media>)dataJsonAsList);
    }
}