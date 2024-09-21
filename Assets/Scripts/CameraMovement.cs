using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{

    const int HALF_WIDTH = 860;
    const int HALF_HEIGHT = 540;
    [Range(0, HALF_WIDTH)]
    public float xBorder;
    [Range(0, HALF_HEIGHT)]
    public float yBorder;
    [Range(0, 50)]
    public float speed;

    Vector3 currentPosition;
    Quaternion defaultRotation;
    [SerializeField]
    Vector3 topViewPos;
    [SerializeField]
    Vector3 topViewRot;

    bool topVision;

    // Start is called before the first frame update
    void Start()
    {
        this.defaultRotation = this.transform.rotation;
        this.currentPosition = this.transform.position;
        topVision = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get current mouse position
        Vector2 pos = Input.mousePosition;
        Vector3 rotation = Vector2.zero;
        //Debug.Log(Input.mousePosition.x);

        //normalize the value from -HALF to +HALF
        float distX = pos.x - HALF_WIDTH;
        float distY = pos.y - HALF_HEIGHT;
        //if its greater than the border you can move the camera
        if (Mathf.Abs(distX) > xBorder && !topVision)
        {
            //the ? operator is needed to clamp the rotation
            //check the direction
            if (distX < 0)
                //ROTATE LEFT
                rotation.y = -speed * Time.fixedDeltaTime * (this.transform.rotation.eulerAngles.y < 245 ? 0:1);
            //Debug.Log("BORDO LEFT");
            else
                //ROTATE RIGHT
                rotation.y = speed * Time.fixedDeltaTime * (this.transform.rotation.eulerAngles.y > 280 ? 0:1);
            //Debug.Log("BORDO RIGHT");

        }

        if (Mathf.Abs(distY) > yBorder && !topVision)
        {
            if (distY < 0)
                //TOP
                rotation.x = speed * Time.fixedDeltaTime * (this.transform.rotation.eulerAngles.x > 20 ? 0 : 1);
            else
                //BOTTOM
                rotation.x = -speed * Time.fixedDeltaTime * (this.transform.rotation.eulerAngles.x < 0.5f ? 0 : 1);

        }
        //Debug.Log(this.transform.rotation.eulerAngles);


        this.transform.Rotate(rotation);
        
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position = currentPosition;
            this.transform.rotation = this.defaultRotation;
            topVision = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.transform.position = this.topViewPos;
            this.transform.rotation = Quaternion.Euler(this.topViewRot);
            topVision = true;
        }
            
    }
}
