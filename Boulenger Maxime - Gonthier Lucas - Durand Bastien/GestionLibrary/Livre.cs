namespace GestionLibrary;

/// <summary>
/// Class pour la gestion des livres
/// </summary>
public class Livre : Media
{
    public string Author { get; set; }

    public string Editor { get; set; }

    public string Genre { get; set; }
    
    /// <summary>
    /// Constructeur de la class Livre
    /// </summary>
    /// <param name="p_title"></param>
    /// <param name="p_numRef"></param>
    /// <param name="p_nbAvailable"></param>
    /// <param name="p_author"></param>
    /// <param name="p_editor"></param>
    /// <param name="p_genre"></param>
    public Livre(string p_title, int p_numRef, int p_nbAvailable, string p_author, string p_editor, string p_genre) : base(p_title, p_numRef, p_nbAvailable)
    {
        Author = p_author;
        Editor = p_title;
        Genre = p_genre;
    }
    /// <summary>
    /// Methode d'affichage heritant de la classe Media, modifiee
    /// </summary>
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Author: {Author}, Editor: {Editor}, Genre: {Genre}, Type: Livre");
    }
}