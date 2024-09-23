namespace GestionLibrary;

// Class pour la gestion des livres
public class Livre : Media
{
    public string Author { get; set; }

    public string Editor { get; set; }

    public string Genre { get; set; }
    
    // Constructeur de la class Livre
    public Livre(string title, int numRef, int nbAvailable, string author, string editor, string genre) : base(title, numRef, nbAvailable)
    {
        Author = author;
        Editor = editor;
        Genre = genre;
    }
    // Methode d'affichage heritant de la classe Media, modifiee
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Author: {Author}, Editor: {Editor}, Genre: {Genre}, Type: Livre");
    }
}