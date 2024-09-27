using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{

    List<Card> cards;
    // Start is called before the first frame update
    void Start()
    {
        this.cards = new List<Card>();
    }

    public void PlaceCard(Card card)
    {
        this.cards.Add(card);
    }

    public void NewTurn()
    {
        foreach (Card card in cards)
        {
            card.AddCounter();
        }
    }
}
