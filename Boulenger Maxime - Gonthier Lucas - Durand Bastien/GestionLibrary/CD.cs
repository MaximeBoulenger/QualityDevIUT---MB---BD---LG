namespace GestionLibrary;


/// <summary>
/// Class pour la gestion des CD
/// </summary>
public class CD : Media
{
    string Artist { get; set; }
	
    string Genre { get; set; }
    
    /// <summary>
    /// Constructeur de la class CD
    /// </summary>
    /// <param name="p_title"></param>
    /// <param name="p_numRef"></param>
    /// <param name="p_nbAvailable"></param>
    /// <param name="p_artist"></param>
    /// <param name="p_genre"></param>
    public CD(string p_title, int p_numRef, int p_nbAvailable, string p_artist, string p_genre) : base(p_title, p_numRef, p_nbAvailable)
    {
        Artist = p_artist;
        Genre = p_genre;
    }
    
    /// <summary>
    /// Méthode d'affichage héritant de la classe Media, modifiée
    /// </summary>
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artist: {Artist}, Genre: {Genre}, Type: CD");
    }
}