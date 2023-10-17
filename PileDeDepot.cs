public class PileDeDepot : PileDeCartes
{
    public PileDeDepot(List<Carte> cartes) : base(cartes) { }
    public void AjouterUneCarte(Carte carte)
    {
        Cartes.Add(carte);
    }

    public Carte DerniereCarte()
    {
        if (Cartes.Count > 0)
        {
            return Cartes[Cartes.Count - 1];
        }
        else
        {
            return null;
        }
    }

    internal void Add(Carte carte)
    {
        throw new NotImplementedException();
    }
}