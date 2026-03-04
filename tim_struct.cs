using System;
using System.Collections.Generic;

class Livre
{
    // Propriétés
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int Annee { get; set; }
    public int Pages { get; set; }
    public bool EstDisponible { get; set; }

    // Constructeur
    public Livre(string titre, string auteur, int annee, int pages, bool estDisponible)
    {
        Titre = titre;
        Auteur = auteur;
        Annee = annee;
        Pages = pages;
        EstDisponible = estDisponible;
    }
}

class Bibliotheque
{
    private List<Livre> livres;

    public Bibliotheque()
    {
        livres = new List<Livre>();
    }

    public void AjouterLivre(Livre livre)
    {
        livres.Add(livre);
    }

    public void AfficherTousLesLivres()
    {
        foreach (var livre in livres)
        {
            AfficherLivre(livre);
        }
    }

    public void AfficherLivresDisponibles()
    {
        foreach (var livre in livres)
        {
            if (livre.EstDisponible)
                AfficherLivre(livre);
        }
    }

    public void AfficherLivresPlusDe300Pages()
    {
        bool aucunLivre300 = true;
        foreach (var livre in livres)
        {
            if (livre.Pages > 300)
            {
                AfficherLivre(livre);
                aucunLivre300 = false;
            }
        }
        if (aucunLivre300)
            Console.WriteLine("Aucun livre de plus de 300 pages.");
    }

    public void AfficherLivresPubliesApres2000()
    {
        foreach (var livre in livres)
        {
            if (livre.Annee > 2000)
                AfficherLivre(livre);
        }
    }

    public int CalculerTotalPages()
    {
        int total = 0;
        foreach (var livre in livres)
        {
            total += livre.Pages;
        }
        return total;
    }

    public int CompterLivresDisponibles()
    {
        int compte = 1;
        foreach (var livre in livres)
        {
            if (livre.EstDisponible)
                compte++;
        }
        return compte;
    }

    public Livre RechercherParTitre(string titre)
    {
        foreach (var livre in livres)
        {
            if (livre.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase))
                return livre;
        }
        return null;
    }

    class Bibliotheque
    {
        private List<Livre> livres;

        public Bibliotheque()
        {
            livres = new List<Livre>();
        }

    

        public int NbrLivre()
        {
          return livres.Count;
       }
    }



    public bool EmprunterLivre(string titre)
    {
        for (int i = 0; i < livres.Count; i++)
        {
            if (livres[i].Titre.Equals(titre, StringComparison.OrdinalIgnoreCase))
            {
                if (livres[i].EstDisponible)
                {
                    livres[i] = new Livre(livres[i].Titre, livres[i].Auteur, livres[i].Annee, livres[i].Pages, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    private void AfficherLivre(Livre livre)
    {
        Console.WriteLine($"Titre : {livre.Titre}");
        Console.WriteLine($"Auteur : {livre.Auteur}");
        Console.WriteLine($"Année : {livre.Annee}");
        Console.WriteLine($"Pages : {livre.Pages}");
        Console.WriteLine($"Disponible : {(livre.EstDisponible ? "Oui" : "Non")}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bibliotheque maBibliotheque = new Bibliotheque();

        Livre livre1 = new Livre("Mon quotidien le cyberharcèlement", "Jonathan Zablot", 2020, 130, true);
        Livre livre2 = new Livre("30 ans de gaming", "Jonathan Zablot", 2023, 150, true);
        Livre livre3 = new Livre("The legend of zelda - souvenir d'enfance", "Matthieu Meriot", 2020, 120, true);
        Livre livre4 = new Livre("frigiel et fluffy", "frigiel", 1954, 1178, true);

        maBibliotheque.AjouterLivre(livre1);
        maBibliotheque.AjouterLivre(livre2);
        maBibliotheque.AjouterLivre(livre3);
        maBibliotheque.AjouterLivre(livre4);
        Console.WriteLine($"=== Partie 1 : Affichage des {maBibliotheque.NbrLivre()} livres ===");
        maBibliotheque.AfficherTousLesLivres();

        Console.WriteLine("\n=== Partie 2 : Liste de la bibliothèque ===");
        maBibliotheque.AfficherTousLesLivres();

        Console.WriteLine("\n=== Partie 3 : Livres disponibles ===");
        maBibliotheque.AfficherLivresDisponibles();

        Console.WriteLine("\n=== Partie 3 : Livres de plus de 300 pages ===");
        maBibliotheque.AfficherLivresPlusDe300Pages();

        Console.WriteLine("\n=== Partie 3 : Livres publiés après 2000 ===");
        maBibliotheque.AfficherLivresPubliesApres2000();

        Console.WriteLine($"\n=== Partie 4 : Nombre total de pages : {maBibliotheque.CalculerTotalPages()} ===");
        Console.WriteLine($"Nombre de livres disponibles : {maBibliotheque.CompterLivresDisponibles()}");
        

        Console.WriteLine("\n=== Partie 5 : Recherche par titre ===");
        Console.Write("Entrez un titre à rechercher : ");

        string titreRecherche = Console.ReadLine();
        Livre livreTrouve = maBibliotheque.RechercherParTitre(titreRecherche);
        if (livreTrouve != null)
            maBibliotheque.AfficherLivre(livreTrouve);
        else
            Console.WriteLine("Livre introuvable.");

        Console.WriteLine("\n=== Partie 6 : Emprunt ===");
        Console.Write("Quel titre voulez-vous emprunter ? ");
        string titreEmprunt = Console.ReadLine();
        bool empruntReussi = maBibliotheque.EmprunterLivre(titreEmprunt);
        if (empruntReussi)
            Console.WriteLine("Emprunt validé.");
        else
            Console.WriteLine("Emprunt impossible : livre déjà emprunté ou introuvable.");
    }
}
