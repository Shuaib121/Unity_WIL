using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBead : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 mOffset;
    private float oldMousePosition;
    private bool isSelected;
    private bool isMoving;
    public bool isHittingRightSide;
    public bool isHittingLeftSide;
    private float mZCoord;
    public float moveSpeed = 1000f;
    private int collisionCounter = 0;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(collisionCounter == 0)
        {
            isHittingLeftSide = false;
            isHittingRightSide = false;
        }


        if (oldMousePosition != GetMouseAsWorldPoint().x)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        StartCoroutine(TrackMousePosition());
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    collisionCounter++;

    //    if (collision.gameObject.tag == "AbacusLeft" )
    //    {
    //        Debug.Log("HIT1");
    //        isHittingLeftSide = true;
    //        return;
    //    }

    //    else if (collision.gameObject.tag == "AbacusRight")
    //    {
    //        Debug.Log("HIT2");
    //        isHittingRightSide = true;
    //        return;
    //    }

    //    if (collision.gameObject.GetComponent<DragBead>().isHittingLeftSide == true)
    //    {
    //        isHittingLeftSide = true;
    //    }

    //    if(collision.gameObject.GetComponent<DragBead>().isHittingRightSide == true)
    //    {
    //        isHittingRightSide = true;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
        
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    collisionCounter--;

    //    if (collision.gameObject.tag == "AbacusLeft")
    //    {
    //        isHittingLeftSide = false;
    //        return;
    //    }

    //    else if (collision.gameObject.tag == "AbacusRight")
    //    {
    //        isHittingRightSide = false;
    //        return;
    //    }

    //    else if(collision.gameObject.GetComponent<DragBead>().isHittingLeftSide == true)
    //    {
    //        isHittingLeftSide = false;
    //    }

    //    else if(collision.gameObject.GetComponent<DragBead>().isHittingRightSide == true)
    //    {
    //        isHittingRightSide = false;
    //    }
    //}

    
    void OnMouseDown()
    {
        isSelected = true;

        //moveSpeed = moveSpeed * 10;
        //rb.mass = rb.mass * 10;

        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseUp()
    {
        isSelected = false;
        //moveSpeed = moveSpeed / 10;
        //rb.mass = rb.mass / 10;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if(GetMouseAsWorldPoint().x > transform.position.x + 0.05f && isHittingRightSide == false)
        {
            rb.AddForce(Vector3.right* moveSpeed *Time.deltaTime);
        }
        
        else if(GetMouseAsWorldPoint().x < transform.position.x-0.05f && isHittingLeftSide == false)
        {
            rb.AddForce(Vector3.left* moveSpeed *Time.deltaTime);
        }
    }

    IEnumerator TrackMousePosition()
    {
        oldMousePosition = GetMouseAsWorldPoint().x;
        yield return new WaitForSeconds(0.25f);
    }
    
}
