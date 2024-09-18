namespace DefaultNamespace;

public class CD : Media
{
    string Artist { get; set; }
	
	string Genre { get; set; }

	public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artist: {Artist}, Genre: {Genre}, Type: CD");
        }
}