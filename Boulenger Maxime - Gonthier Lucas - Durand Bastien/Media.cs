namespace DefaultNamespace;

public class Media
{
    private string Title { get; set; }
    
    private int NumRef { get; set; }
    
    private int NbAvailable { get; set; }

	public virtual void AfficherInfos()
        {
            Console.WriteLine($"Title: {Title}, NumRef: {NumRef}, NbAvailable: {NbAvailable}");
        }
}