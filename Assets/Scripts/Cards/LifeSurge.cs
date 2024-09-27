using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSurge : Card
{
    public LifeSurge() : base()
    {
        this.text = "Gain X life";
        this.cost = 1;
        this.cardname = "Life Surge";
    }

    public override void PlayCard()
    {
        Debug.Log("LIFE SURGE CARD PLAYED");
    }
}
