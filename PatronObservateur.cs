// création de l'interface patron observateur 
public interface PatronObservateur
{
    void Notificateur(Joueur joueurActuel);
}

// Classe abstraite pour le sujet
public abstract class Sujet
{
    private List<PatronObservateur> observateurs = new List<PatronObservateur>();

    public void AjouterObservateur(PatronObservateur observateur)
    {
        observateurs.Add(observateur);
    }
    public void NotifierObservateurs(Joueur joueurActuel)
    {
        foreach (PatronObservateur observateur in observateurs)
        {
            observateur.Notificateur(joueurActuel);
        }
    }
}
