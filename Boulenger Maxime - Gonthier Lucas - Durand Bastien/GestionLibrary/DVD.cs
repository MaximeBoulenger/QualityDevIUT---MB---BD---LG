namespace GestionLibrary;

public class DVD : Media
{
    public string Director { get; set; }
    public int Duration { get; set; }
    
    public string Genre { get; set; }

    public List<string> Languages { get; set; }
    
    public DVD(string title, int numRef, int nbAvailable, string director, int duration, string genre, List<string> languages) : base(title, numRef, nbAvailable)
    {
        Director = director;
        Duration = duration;
        Genre = genre;
        Languages = languages;
    }
    //méthode d'affichage héritant de la classe Media, modifiée
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Director: {Director}, Duration: {Duration} minutes, Genre: {Genre}, Languages: {string.Join(", ", Languages)}, Type: DVD");
    }
}