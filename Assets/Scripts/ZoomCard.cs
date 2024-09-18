using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool canZoom;
    //CURRENTLY USELESS
    // Start is called before the first frame update
    void Start()
    {
       // zoom = false;
        canZoom = false;

    }

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.canZoom = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.canZoom = false;
    }
}
