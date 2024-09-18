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
    [Range(0, 3)]
    public float speed;

    Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        this.defaultRotation = this.transform.rotation;
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
        if (Mathf.Abs(distX) > xBorder)
        {

            //check the direction
            if (distX < 0)
                rotation.y = -speed;
            //Debug.Log("BORDO LEFT");
            else
                rotation.y = speed;
            //Debug.Log("BORDO RIGHT");
        }

        if (Mathf.Abs(distY) > yBorder)
        {
            if (distY < 0)
                rotation.x = speed;
            else
                rotation.x = -speed;
        }
        Debug.Log(this.transform.rotation.eulerAngles);
        this.transform.Rotate(rotation);
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.rotation = this.defaultRotation;
        }
    }
}
