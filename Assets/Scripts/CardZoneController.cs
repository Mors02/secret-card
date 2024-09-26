using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class used to control the cards in hand
 */
public class CardZoneController : MonoBehaviour
{
    GameObject zoomedCard;
    bool zoom;
    int highlightedCard;

    [SerializeField]
    List<Card> hand;
    void Start()
    {
        this.highlightedCard = -1;
        this.zoomedCard = GameObject.FindGameObjectWithTag("ZoomedCard");
        this.zoomedCard.SetActive(false);
        this.hand = new List<Card>();
    }

    //Highlight the card currently hovered
    public void SetCard(int cardIdx, bool inHand)
    {
        //highlight the single card and the one on the left and the right
        this.highlightedCard = cardIdx;
        if (cardIdx > 0 && inHand)
        {
            this.transform.GetChild(cardIdx - 1).GetComponent<Animator>().SetTrigger("HideLeft");
        }
        if (cardIdx < this.transform.childCount-1 && inHand)
        {
            this.transform.GetChild(cardIdx + 1).GetComponent<Animator>().SetTrigger("HideRight");
        }
    }

    //No cards are hovered
    public void ResetCard(int cardIdx, bool inHand)
    {
        //animations go back to default state
        this.highlightedCard = -1;
        if (cardIdx > 0 && inHand)
        {
            this.transform.GetChild(cardIdx - 1).GetComponent<Animator>().SetTrigger("ShowLeft");
        }
        if (cardIdx < this.transform.childCount-1 && inHand)
        {
            this.transform.GetChild(cardIdx + 1).GetComponent<Animator>().SetTrigger("ShowRight");
        }
    }

    public bool IsCurrentCardHighlighted(int card)
    {
        return this.highlightedCard == card;
    }

    public bool IsACardNotHighlighted()
    {
        return this.highlightedCard == -1;
    }

    //To zoom an hovered card
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            this.zoom = true;
        } else
        {
            this.zoom = false;
        }

        if (zoom && this.highlightedCard != -1)
        {
            //select active card
            this.zoomedCard.SetActive(true);
            //setup zoom card
            this.zoomedCard.GetComponent<CardUI>().Setup(this.transform.GetChild(this.highlightedCard).GetComponent<CardUI>().card);
        }
        else
        {
            this.zoomedCard.SetActive(false);
        }
    }

    public void AddCard(Card card)
    {
        //Debug.Log(card.cardname);
        this.hand.Add(card);
        GameObject cardPrefab = GameObject.Instantiate(GameAssets.i.CardPrefabUI, this.transform);
        cardPrefab.GetComponent<CardUI>().Setup(card);
        cardPrefab.GetComponent<Animator>().SetTrigger("Draw");

    }

    public void RemoveCard(Card card)
    {
        this.hand.Remove(card);
        PrintHand();

    }

    private void PrintHand()
    {
        string list = "";
        foreach (Card card in this.hand)
        {
            list += card.cardname + ", ";
        }
        Debug.Log(list);
    }

}
