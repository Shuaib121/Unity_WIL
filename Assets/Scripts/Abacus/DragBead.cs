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
    private bool isLoaded = false;
    private bool mouseIsDown;
    public bool isHittingRightSide;
    public bool isHittingLeftSide;
    private float mZCoord;
    public float moveSpeed = 1000f;
    private int collisionCounter = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitForBead());
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bead" && isLoaded)
        {
            FindObjectOfType<AbacusSound>().PlaySound();
        }
    }

    void OnMouseDown()
    {
        isSelected = true;

        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseUp()
    {
        isSelected = false;
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

    IEnumerator WaitForBead()
    {
        yield return new WaitForSeconds(0.5f);
        isLoaded = true;
    }

}
