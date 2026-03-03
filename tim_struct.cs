using System;
using System.Collections.Generic;

struct Livre
{
    public string Titre;
    public string Auteur;
    public int Annee;
    public int Pages;
    public bool EstDisponible;
}

class Program
{
    static void Main()
    {
        
        Livre livre1 = new Livre
        {
            Titre = "Mon quotidien le cyberharcèlement",
            Auteur = "Jonathan Zablot",
            Annee = 2020,
            Pages = 130,
            EstDisponible = true
        };

        Livre livre2 = new Livre
        {
            Titre = "30 ans de gaming",
            Auteur = "Jonathan Zablot",
            Annee = 2023,
            Pages = 150,
            EstDisponible = true
        };

        Livre livre3 = new Livre
        {
            Titre = "The legend of zelda - souvenir d'enfance",
            Auteur = "Matthieu Meriot",
            Annee = 2020,
            Pages = 120,
            EstDisponible = true
        };

    
        Console.WriteLine("=== Partie 1 : Affichage des 3 livres ===");
        AfficherLivre(livre1);
        AfficherLivre(livre2);
        AfficherLivre(livre3);

        
        List<Livre> bibliotheque = new List<Livre> { livre1, livre2, livre3 };

        Console.WriteLine("\n=== Partie 2 : Liste de la bibliothèque ===");
        foreach (var livre in bibliotheque)
        {
            AfficherLivre(livre);
        }

        Console.WriteLine("\n=== Partie 3 : Livres disponibles ===");
        foreach (var livre in bibliotheque)
        {
            if (livre.EstDisponible)
                AfficherLivre(livre);
        }

        Console.WriteLine("\n=== Partie 3 : Livres de plus de 300 pages ===");
        bool aucunLivre300 = true;
        foreach (var livre in bibliotheque)
        {
            if (livre.Pages > 300)
            {
                AfficherLivre(livre);
                aucunLivre300 = false;
            }
        }
        if (aucunLivre300)
            Console.WriteLine("Aucun livre de plus de 300 pages.");

        Console.WriteLine("\n=== Partie 3 : Livres publiés après 2000 ===");
        foreach (var livre in bibliotheque)
        {
            if (livre.Annee > 2000)
                AfficherLivre(livre);
        }

        int totalPages = 0;
        int livresDisponibles = 0;
        foreach (var livre in bibliotheque)
        {
            totalPages += livre.Pages;
            if (livre.EstDisponible)
                livresDisponibles++;
        }
        Console.WriteLine($"\n=== Partie 4 : Nombre total de pages : {totalPages} ===");
        Console.WriteLine($"Nombre de livres disponibles : {livresDisponibles}");

        
        Console.WriteLine("\n=== Partie 5 : Recherche par titre ===");
        Console.Write("Entrez un titre à rechercher : ");
        string titreRecherche = Console.ReadLine();
        bool trouve = false;
        foreach (var livre in bibliotheque)
        {
            if (livre.Titre.Equals(titreRecherche, StringComparison.OrdinalIgnoreCase))
            {
                AfficherLivre(livre);
                trouve = true;
                break;
            }
        }
        if (!trouve)
            Console.WriteLine("Livre introuvable.");

      
        Console.WriteLine("\n=== Partie 6 : Emprunt ===");
        Console.Write("Quel titre voulez-vous emprunter ? ");
        string titreEmprunt = Console.ReadLine();
        bool empruntReussi = false;
        for (int i = 0; i < bibliotheque.Count; i++)
        {
            if (bibliotheque[i].Titre.Equals(titreEmprunt, StringComparison.OrdinalIgnoreCase))
            {
                if (bibliotheque[i].EstDisponible)
                {
                    bibliotheque[i] = new Livre
                    {
                        Titre = bibliotheque[i].Titre,
                        Auteur = bibliotheque[i].Auteur,
                        Annee = bibliotheque[i].Annee,
                        Pages = bibliotheque[i].Pages,
                        EstDisponible = false
                    };
                    Console.WriteLine("Emprunt validé.");
                }
                else
                {
                    Console.WriteLine("Emprunt impossible : livre déjà emprunté.");
                }
                empruntReussi = true;
                break;
            }
        }
        if (!empruntReussi)
            Console.WriteLine("Emprunt impossible : livre introuvable.");
    }

    static void AfficherLivre(Livre livre)
    {
        Console.WriteLine($"Titre : {livre.Titre}");
        Console.WriteLine($"Auteur : {livre.Auteur}");
        Console.WriteLine($"Année : {livre.Annee}");
        Console.WriteLine($"Pages : {livre.Pages}");
        Console.WriteLine($"Disponible : {(livre.EstDisponible ? "Oui" : "Non")}");
        Console.WriteLine();
    }
}

