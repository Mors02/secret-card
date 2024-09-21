using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    Stack<Card> cards;

    CardZoneController hand;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (this.cards == null) 
            {
                this.cards = new Stack<Card>();
                this.cards.Push(new EmmasGift());
                this.cards.Push(new EmmasGift());
                this.cards.Push(new EmmasGift());
                this.cards.Push(new EmmasGift());
                this.cards.Push(new EmmasGift());
        }
        hand = GameObject.FindGameObjectWithTag("CardZone").GetComponent<CardZoneController>();
    }

    public void Draw()
    {
        if (this.cards.Count > 0)
        {
            Card card = this.cards.Pop();
            Debug.Log(card.cardname);
            hand.AddCard(card);
            this.animator.SetTrigger("Draw");
        } else
        {
            Debug.Log("EMPTY DECK");
        }
        
    }
}
