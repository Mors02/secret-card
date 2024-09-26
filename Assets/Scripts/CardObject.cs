using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObject : MonoBehaviour
{

    public Card card;
    public TMP_Text currentCounters;
    public GameObject visibleCard;
    public TMP_Text textBox;
    public TMP_Text costBox;
    public TMP_Text nameBox;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.visibleCard.SetActive(false);
    }

    private void OnMouseEnter()
    {
        this.animator.SetTrigger("Show");
        this.visibleCard.SetActive(true);
        this.currentCounters.gameObject.SetActive(false);
    }

    private void OnMouseExit()
    {
        this.visibleCard.SetActive(false);
        this.currentCounters.gameObject.SetActive(true);
    }

    public void Setup(Card card)
    {
        this.card = card;
        this.textBox.text = card.text;
        this.costBox.text = card.cost.ToString();
        this.nameBox.text = card.cardname;
    }

}
