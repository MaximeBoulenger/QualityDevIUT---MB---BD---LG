namespace GestionLibrary;

// Class pour la gestion de tous les medias (CD, DVD, Livre)
public class Media
{
    public string Title { get; private set; }
    
    public int NumRef { get; private set; }
    
    public int NbAvailable { get; private set; }
    
    // Constructeur de la class Media
    public Media(string title, int numRef, int nbAvailable)
    {
        Title = title;
        NumRef = numRef;
        NbAvailable = nbAvailable;
    }

    // Methode d'affichage des medias
    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Title: {Title}, NumRef: {NumRef}, NbAvailable: {NbAvailable}");
    }
    // Surcharge de l'operateur + 
    public static Media operator +(Media p_media, int p_quantity)
    {
        p_media.NbAvailable += p_quantity;
        return p_media;
    }

    // Surcharge de l'operateur - 
    public static Media operator -(Media p_media,int p_quantity)
    {
        if (p_media.NbAvailable < p_quantity)
        {
            throw new InvalidOperationException("Quantité à retirer dépasse le nombre disponible.");
        }
        
        p_media.NbAvailable -= p_quantity;
        return p_media;
    }
    
    // Méthode pour emprunter un exemplaire
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

    // Méthode pour retourner un exemplaire
    public void Return()
    {
        NbAvailable++; // Augmente le nombre d'exemplaires disponibles
        Console.WriteLine($"{Title} has been returned. Copies available: {NbAvailable}");
    }
    
}