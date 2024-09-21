using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public string text;
    public int cost;
    public string cardname;
    protected int counters;
    // Start is called before the first frame update

    void AddCounter()
    {
        this.counters++;
    }

    /*
    public Card(string text, int cost, string cardname)
    {
        this.text = text;
        this.cost = cost;
        this.cardname = cardname;
        this.counters = 0;
    }*/

    public abstract void PlayCard();

}
