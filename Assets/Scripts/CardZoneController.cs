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
    void Start()
    {
        this.highlightedCard = -1;
        this.zoomedCard = GameObject.FindGameObjectWithTag("ZoomedCard");
        this.zoomedCard.SetActive(false);
    }

    //Highlight the card currently hovered
    public void SetCard(int cardIdx)
    {
        this.highlightedCard = cardIdx;
        if (cardIdx > 0)
        {
            this.transform.GetChild(cardIdx - 1).GetComponent<Animator>().SetTrigger("HideLeft");
        }
        if (cardIdx < this.transform.childCount-1)
        {
            this.transform.GetChild(cardIdx + 1).GetComponent<Animator>().SetTrigger("HideRight");
        }
    }

    //No cards are hovered
    public void ResetCard(int cardIdx)
    {
        this.highlightedCard = -1;
        if (cardIdx > 0)
        {
            this.transform.GetChild(cardIdx - 1).GetComponent<Animator>().SetTrigger("ShowLeft");
        }
        if (cardIdx < this.transform.childCount-1)
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
            this.zoomedCard.SetActive(true);
            this.zoomedCard.GetComponent<Card>().Setup(this.transform.GetChild(this.highlightedCard).GetComponent<Card>());
        }
        else
        {
            this.zoomedCard.SetActive(false);
        }
    }

}
