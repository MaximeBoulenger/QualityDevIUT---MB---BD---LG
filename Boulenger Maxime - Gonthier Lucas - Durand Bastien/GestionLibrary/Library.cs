using System.Text.Json;

namespace GestionLibrary;

/// <summary>
/// Class pour la gestion de la librairie
/// </summary>
public class Library
{
    private List<Media> mediaCollection = new List<Media>();
    private List<Borrow> borrows = new List<Borrow>();

    /// <summary>
    /// Ajout d'un media
    /// </summary>
    /// <param name="p_media"></param>
    public void AddMedia(Media p_media)
    {
        mediaCollection.Add(p_media);
    }

    /// <summary>
    /// Suppression d'un media
    /// </summary>
    /// <param name="p_title"></param>
    /// <returns></returns>
    public bool RemoveMedia(string p_title)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.Title == p_title);
        if (media != null)
        {
            mediaCollection.Remove(media);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Emprunt d'un media
    /// </summary>
    /// <param name="p_title"></param>
    /// <param name="p_user"></param>
    /// <returns></returns>
    public bool BorrowMedia(string p_title, string p_user)
    {
        Media media = mediaCollection.FirstOrDefault(m => m.Title == p_title && m.NbAvailable > 0);
        if (media != null)
        {
            media.Borrow(); // Decroit le nombre de copies disponible
            borrows.Add(new Borrow(p_user, media)); // Ajout de l'emprunt
            return true;
        }
        return false;
    }

    /// <summary>
    /// Retour d'un media
    /// </summary>
    /// <param name="p_title"></param>
    /// <param name="p_user"></param>
    /// <returns></returns>
    public bool ReturnMedia(string p_title, string p_user)
    {
        Borrow borrow = borrows.FirstOrDefault(b => b.Media.Title == p_title && b.User == p_user);
        if (borrow != null)
        {
            borrow.Media.Return(); // Acroit le nombre de copies totales
            borrows.Remove(borrow); // Enleve l'emprunt
            return true;
        }
        return false;
    }

    /// <summary>
    /// Rechercher un media avec son titre ou son auteur
    /// </summary>
    /// <param name="p_searchCriteria"></param>
    /// <returns></returns>
    public List<Media> SearchMedia(string p_searchCriteria)
    {
        return mediaCollection.Where(m =>
            m.Title.Contains(p_searchCriteria, StringComparison.OrdinalIgnoreCase) ||
            (m is Livre && ((Livre)m).Author.Contains(p_searchCriteria, StringComparison.OrdinalIgnoreCase))
        ).ToList();
    }

    /// <summary>
    /// Lister les medias emprunte
    /// </summary>
    /// <param name="p_user"></param>
    /// <returns></returns>
    public List<Borrow> ListBorrowsByUser(string p_user)
    {
        return borrows.Where(b => b.User == p_user).ToList();
    }

    /// <summary>
    /// Afficher les stats de la librairie
    /// </summary>
    public void DisplayStatistics()
    {
        int totalMedia = mediaCollection.Count;
        int totalAvailableCopies = mediaCollection.Sum(m => m.NbAvailable);
        int totalBorrows = borrows.Count;

        Console.WriteLine($"Total media: {totalMedia}");
        Console.WriteLine($"Total available copies: {totalAvailableCopies}");
        Console.WriteLine($"Total borrows: {totalBorrows}");
    }

    /// <summary>
    /// Sauvegarde la library
    /// </summary>
    /// <param name="p_fileName">Nom de fichier par défaut : data.json</param>
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

    /// <summary>
    /// Importe la library d'un fichier json
    /// </summary>
    /// <param name="p_fileName">Nom de fichier par défaut : data.json</param>
    public void Import(string p_fileName = "data.json")
    {
        var dataFile = File.ReadAllText(p_fileName);
        var dataJsonAsList = JsonSerializer.Deserialize<List<Media>>(dataFile);
        mediaCollection.AddRange((IEnumerable<Media>)dataJsonAsList);
    }
}