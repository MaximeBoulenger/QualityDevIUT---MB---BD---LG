namespace GestionLibrary;

// Class pour la gestion des CD
public class CD : Media
{
    string Artist { get; set; }
	
    string Genre { get; set; }

    // Constructeur de la class CD
    public CD(string title, int numRef, int nbAvailable, string artist, string genre) : base(title, numRef, nbAvailable)
    {
        Artist = artist;
        Genre = genre;
    }
    
    //méthode d'affichage héritant de la classe Media, modifiée
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artist: {Artist}, Genre: {Genre}, Type: CD");
    }
}