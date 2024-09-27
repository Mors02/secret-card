using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Card
{
    public string text;
    public int cost;
    public string cardname;
    public int counters;
    public UnityEvent onAddCounter;
    public UnityEvent onCardPlayed;
    // Start is called before the first frame update

    public void AddCounter()
    {
        this.counters++;
        this.onAddCounter.Invoke();
    }

    public void AddCounter(int counter)
    {
        this.counters += counter;
        this.onAddCounter.Invoke();
    }

    public void RemoveCounter(int counter)
    {
        this.counters -= counter;
        this.onAddCounter.Invoke();
    }

    public Card()
    {
        if (onAddCounter == null)
        {
            onAddCounter = new UnityEngine.Events.UnityEvent();
        }
        if (onCardPlayed == null)
        {
            onCardPlayed = new UnityEngine.Events.UnityEvent();
        }
    }

    public abstract void PlayCard();

}
