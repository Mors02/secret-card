using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/***
 * Base class that controls the base card behaviour
 * 
 */
public class CardUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    public TMP_Text textBox;
    public TMP_Text costBox;
    public TMP_Text nameBox;
    public Card card;
    Vector3 mousePos;
    Vector3 defaultPos;
    GameObject hover;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        //this.card = new EmmasGift();
        this.textBox.text = this.card.text;
        this.costBox.text = this.card.cost.ToString();
        this.nameBox.text = this.card.cardname;
        this.defaultPos = this.transform.position;
    }

    public void Setup(Card card)
    {
        this.card = card;        
        this.textBox.text = this.card.text;
        this.costBox.text = this.card.cost.ToString();
        this.nameBox.text = this.card.cardname;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("DRAGGING");
        //translate 2d pixel coordinates to 3d coordinates
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
        this.transform.position = new Vector3(worldPos.x, .25f, worldPos.z);
        Vector3 offset = new Vector3(0, 200, 0);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(worldPos, worldPos - offset, out hitInfo, 200f, mask))
        {
            if (!hitInfo.collider.transform.CompareTag("Board"))
            {
                ChangeColor(Color.red);
            } else
            {
                ChangeColor(Color.green);
            }
            Debug.Log(hitInfo.transform.gameObject.name);
            this.hover.transform.position = hitInfo.point;
        } else
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
        //Debug.Log("BEGIN");
        //save current world to screen point position as offset
        mousePos = Input.mousePosition - getMousePos();
        GameObject hover = GameObject.Instantiate(GameAssets.i.CardHover);
        this.hover = hover;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = defaultPos;
        Destroy(this.hover);
    }

    public CardUI(Card card)
    {
        this.Setup(card);
    }

    private Vector3 getMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void ChangeColor(Color color)
    {
        Material mat = this.hover.gameObject.GetComponent<MeshRenderer>().material;
        mat.color = color;
    }

}
