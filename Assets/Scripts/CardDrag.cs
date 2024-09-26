using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Card card;
    public CardUI cardUI;
    bool canPlace;
    Vector3 lastPosition;
    GameObject hover;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        this.canPlace = false;
        this.card = cardUI.card;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("DRAGGING");
        //translate 2d pixel coordinates to 3d coordinates
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
        //move only the draggable layer (aka the graphics)
        this.transform.position = new Vector3(worldPos.x, .25f, worldPos.z);
        Vector3 offset = new Vector3(0, 200, 0);
        RaycastHit hitInfo;
        //raycast
        if (Physics.Raycast(worldPos, worldPos - offset, out hitInfo, 200f, mask))
        {
            //if you hit anything other than the board
            if (!hitInfo.collider.transform.CompareTag("Board"))
            {
                //cant place
                ChangeColor(Color.red);
                canPlace = false;
            }
            else
            {
                ChangeColor(Color.green);
                canPlace = true;
            }
            //move the transparent hover
            this.hover.transform.position = hitInfo.point;
            lastPosition = hitInfo.point;
        }
        else
        {
            //Debug.Log("NO HIT");
        }


    }

    public void OnDrawGizmos()
    {

        //Gizmos.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //save the hover object
        GameObject hover = GameObject.Instantiate(GameAssets.i.CardHover);
        this.hover = hover;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //put it back at 0,0,0 of parent (localpos)
        this.transform.localPosition = Vector3.zero;
        Destroy(this.hover);
        if (canPlace)
        {
            //place the card object
            GameObject card = GameObject.Instantiate(GameAssets.i.PlacedCard, lastPosition, Quaternion.identity); //, 
            //update the boardstate and the hand
            GameAssets.i.Board.GetComponent<BoardState>().PlaceCard(this.card);
            GameAssets.i.Hand.RemoveCard(this.card);
            //animate and destroy the ui element
            card.GetComponent<Animator>().SetTrigger("Place");
            //call the animation trigger to make normal the other cards in hand
            GameAssets.i.Hand.ResetCard(this.transform.parent.GetSiblingIndex(), true);
            Destroy(this.transform.parent.gameObject);


        }
    }

    private void ChangeColor(Color color)
    {
        Material mat = this.hover.gameObject.GetComponent<MeshRenderer>().material;
        mat.color = color;
    }
}
