namespace GestionLibrary;

/// <summary>
/// Class pour la gestion de tous les medias (CD, DVD, Livre)
/// </summary>
public class Media
{
    public string Title { get; private set; }
    
    public int NumRef { get; private set; }
    
    public int NbAvailable { get; private set; }
    
    /// <summary>
    /// Constructeur de la class Media
    /// </summary>
    /// <param name="p_title"></param>
    /// <param name="p_numRef"></param>
    /// <param name="p_nbAvailable"></param>
    public Media(string p_title, int p_numRef, int p_nbAvailable)
    {
        Title = p_title;
        NumRef = p_numRef;
        NbAvailable = p_nbAvailable;
    }

    /// <summary>
    /// Methode d'affichage des medias
    /// </summary>
    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Title: {Title}, NumRef: {NumRef}, NbAvailable: {NbAvailable}");
    }
    /// <summary>
    /// Surcharge de l'operateur + 
    /// </summary>
    /// <param name="p_media"></param>
    /// <param name="p_quantity"></param>
    /// <returns></returns>
    public static Media operator +(Media p_media, int p_quantity)
    {
        p_media.NbAvailable += p_quantity;
        return p_media;
    }

    /// <summary>
    /// Surcharge de l'operateur - 
    /// </summary>
    /// <param name="p_media"></param>
    /// <param name="p_quantity"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Media operator -(Media p_media,int p_quantity)
    {
        if (p_media.NbAvailable < p_quantity)
        {
            throw new InvalidOperationException("Quantité à retirer dépasse le nombre disponible.");
        }
        
        p_media.NbAvailable -= p_quantity;
        return p_media;
    }
    
    /// <summary>
    /// Méthode pour emprunter un exemplaire
    /// </summary>
    /// <returns>bool</returns>
    public bool Borrow()
    {
        if (NbAvailable > 0)
        {
            NbAvailable--; // Réduit le nombre d'exemplaires disponibles
            Console.WriteLine($"{Title} has been borrowed. Copies left: {NbAvailable}");
            return true;
        }
        else
        {
            Console.WriteLine($"{Title} is not available for borrowing.");
            return false;
        }
    }

    /// <summary>
    /// Méthode pour retourner un exemplaire
    /// </summary>
    public void Return()
    {
        NbAvailable++; // Augmente le nombre d'exemplaires disponibles
        Console.WriteLine($"{Title} has been returned. Copies available: {NbAvailable}");
    }
    
}