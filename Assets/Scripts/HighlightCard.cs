using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform t;
    public CardZoneController parent;
    public Animator animator;
    public bool inHand;
    // Start is called before the first frame update
    void Start()
    {
        //this.currentIndex = 
        this.parent = GameAssets.i.Hand;
        //Debug.Log(this.gameObject.name + " " + this.currentPos);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.parent.IsACardNotHighlighted())
        {
            animator.SetTrigger("Highlight");
            this.parent.SetCard(t.GetSiblingIndex());
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.parent.IsCurrentCardHighlighted(t.GetSiblingIndex()))
        {
            animator.SetTrigger("Lowlight");
            this.parent.ResetCard(t.GetSiblingIndex());
        }
    }
}
