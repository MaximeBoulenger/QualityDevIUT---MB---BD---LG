namespace DefaultNamespace;

public class Media
{
    public string Title { get; private set; }
    
    public int NumRef { get; private set; }
    
    public int NbAvailable { get; private set; }
    
    public Media(string title, int numRef, int nbAvailable)
    {
        Title = title;
        NumRef = numRef;
        NbAvailable = nbAvailable;
    }
    
    private int NumRef { get; set; }
    
    private int NbAvailable { get; set; }

	public virtual void AfficherInfos()
        {
            Console.WriteLine($"Title: {Title}, NumRef: {NumRef}, NbAvailable: {NbAvailable}");
        }
    //Surcharger opérateur + 
    public static Media operator +(Media p_media, int p_quantity)
    {
        p_media.NbAvailable += p_quantity;
        return p_media;
    }

    //Surcharge opérateur - 
    public static Media operator -(Media p_media,int p_quantity)
    {
        if (p_media.NbAvailable < p_quantity)
        {
            throw new InvalidOperationException("Quantité à retirer dépasse le nombre disponible.");
        }
        
        p_media.NbAvailable -= p_quantity;
        return p_media;
    }
}