using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/***
 * Base class that controls the base card behaviour
 * 
 */
public class Card : MonoBehaviour
{
    public string text;
    public int cost;
    int counters;
    public TMP_Text textBox;
    public TMP_Text costBox;

    // Start is called before the first frame update
    void Start()
    {
        this.counters = 0;
        this.textBox.text = this.text;
        this.costBox.text = this.cost.ToString();
    }

    void AddCounter()
    {
        this.counters++;
    }

    public void Setup(Card card)
    {
        this.text = card.text;
        this.textBox.text = this.text;
        this.cost = card.cost;
        this.costBox.text = this.cost.ToString();
        this.counters = card.counters;

    }
}
