namespace DefaultNamespace;

public class DVD : Media
{
    public string Director { get; set; }
    public int Duration { get; set; }
    
    public string Genre { get; set; }

    public List<string> Languages { get; set; }

	//méthode d'affichage héritant de la classe Media, modifiée
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Director: {Director}, Duration: {Duration} minutes, Genre: {Genre}, Languages: {string.Join(", ", Languages)}, Type: DVD");
    }
}