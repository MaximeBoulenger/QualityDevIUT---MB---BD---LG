using System;
using System.Collections.Generic;

namespace GestionLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            //créer des médias
            Livre livre1 = new Livre("Le Seigneur des Anneaux", 1, 3, "J.R.R. Tolkien", "Christian Bourgois",
                "Fantasy");
            Livre livre2 = new Livre("Harry Potter", 2, 2, "J.K. Rowling", "Gallimard", "Fantasy");
            Livre livre3 = new Livre("Le Petit Prince", 3, 1, "Antoine de Saint-Exupéry", "Gallimard",
                "Conte philosophique");
            DVD dvd1 = new DVD("Inception", 4, 2, "Christopher Nolan", 120, "Science-fiction",
                new List<string>() { "English", "French" });
            DVD dvd2 = new DVD("Interstellar", 5, 1, "Christopher Nolan", 130, "Science-fiction",
                new List<string>() { "English", "French" });
            CD cd1 = new CD("Thriller", 6, 3, "Michael Jackson", "Pop");
            CD cd2 = new CD("Back in Black", 7, 2, "AC/DC", "Hard Rock");



            //ajouter les médias à la bibliothèque
            library.AddMedia(livre1 + 2);
            library.AddMedia(livre2 + 4);
            library.AddMedia(livre3 + 1);
            library.AddMedia(dvd1 + 2);
            library.AddMedia(dvd2 + 1);
            library.AddMedia(cd1 + 3);
            library.AddMedia(cd2 + 2);

            //emprunter un média
            try
            {
                library.BorrowMedia("Le Seigneur des Anneaux", "Alice");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //retourner un média
            try
            {
                library.ReturnMedia("Le Seigneur des Anneaux", "Alice");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //afficher les informations des médias
            foreach (Media media in library.SearchMedia("Harry Potter"))
            {
                media.AfficherInfos();
            }

            //enregistrer les médias dans un fichier JSON
            library.Save();

            //charger les médias depuis un fichier JSON
            library.Import();

            //afficher les informations des médias
            foreach (Media media in library.SearchMedia("Harry Potter"))
            {
                media.AfficherInfos();
            }
        }
    }
}