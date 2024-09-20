namespace DefaultNamespace;

public class CD : Media
{
    string Artist { get; set; }
	
	string Genre { get; set; }

	//méthode d'affichage héritant de la classe Media, modifiée
	public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artist: {Artist}, Genre: {Genre}, Type: CD");
        }
}