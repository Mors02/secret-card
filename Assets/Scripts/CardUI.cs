using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/***
 * Base class that controls the base card behaviour
 * 
 */
public class CardUI : MonoBehaviour
{
    
    public TMP_Text textBox;
    public TMP_Text costBox;
    public TMP_Text nameBox;
    public Card card;
    GameObject hover;


    // Start is called before the first frame update
    void Start()
    {
        //this.card = new EmmasGift();
        if (this.card != null)
        {
            this.textBox.text = this.card.text;
            this.costBox.text = this.card.cost.ToString();
            this.nameBox.text = this.card.cardname;
        }
    }

    public void Setup(Card card)
    {
        this.card = card;        
        this.textBox.text = this.card.text;
        this.costBox.text = this.card.cost.ToString();
        this.nameBox.text = this.card.cardname;
    }



    public CardUI(Card card)
    {
        this.Setup(card);
    }

}
