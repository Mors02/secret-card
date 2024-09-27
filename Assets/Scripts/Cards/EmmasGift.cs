using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmasGift : Card
{

    //new public string text = "Draw X cards";
    //new public int cost = 3;
    //new public string cardname = "Emma's Gift";

    public EmmasGift() : base()
    {
        this.text = "Draw X cards";
        this.cost = 3;
        this.cardname = "Emma's Gift";
        //onAddCounter.AddListener();
    }

    public override void PlayCard()
    {
        Debug.Log("EMMA'S GIFT CARD PLAYED");
    }

}
