namespace DefaultNamespace;

public class Livre : Media
{
    string Author { get; set; }

	string Editor { get; set; }

	string Genre { get; set; }

	public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Author: {Author}, Editor: {Editor}, Genre: {Genre}, Type: Livre");
        }
}