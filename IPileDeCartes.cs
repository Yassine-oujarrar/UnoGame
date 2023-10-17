using System;

public interface IPileDeCartes
{
	List<Carte> Cartes { get; set; }

	Carte Piocher();
	void Melanger();
}
