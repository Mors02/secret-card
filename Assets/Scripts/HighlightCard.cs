using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LayoutElement le;
    public Transform t;
    public CardZoneController parent;
    public Animator animator;
    int currentIndex;
    Vector2 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        this.currentIndex = t.GetSiblingIndex();
        this.parent = GameObject.FindGameObjectWithTag("CardZone").GetComponent<CardZoneController>();
        Debug.Log(this.gameObject.name + " " + this.currentPos);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.parent.IsACardNotHighlighted())
        {
            animator.SetTrigger("Highlight");
            this.parent.SetCard(this.currentIndex);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.parent.IsCurrentCardHighlighted(this.currentIndex))
        {
            animator.SetTrigger("Lowlight");
            this.parent.ResetCard(this.currentIndex);
        }

    }
}
