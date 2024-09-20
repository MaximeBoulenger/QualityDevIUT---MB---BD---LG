namespace GestionLibrary;

public class Livre : Media
{
    string Author { get; set; }

    string Editor { get; set; }

    string Genre { get; set; }
    
    public Livre(string title, int numRef, int nbAvailable, string author, string editor, string genre) : base(title, numRef, nbAvailable)
    {
        Author = author;
        Editor = editor;
        Genre = genre;
    }
    //méthode d'affichage héritant de la classe Media, modifiée
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Author: {Author}, Editor: {Editor}, Genre: {Genre}, Type: Livre");
    }
}