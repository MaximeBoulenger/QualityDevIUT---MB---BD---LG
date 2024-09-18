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

	public virtual void AfficherInfos()
        {
            Console.WriteLine($"Title: {Title}, NumRef: {NumRef}, NbAvailable: {NbAvailable}");
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