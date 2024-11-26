using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;

    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private LayerMask movableObjects;
    [SerializeField] private Animator anim;
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Vector3 horizontalMoveTo = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                if(!Physics2D.OverlapCircle(movePoint.position + horizontalMoveTo, 0.2f, whatStopsMovement))
                {
                    Collider2D hit =
                        Physics2D.OverlapCircle(movePoint.position + horizontalMoveTo, 0.2f, movableObjects);
                    if (hit && hit.GetComponent<Movable>().MoveMe(horizontalMoveTo))
                    {
                        movePoint.position += horizontalMoveTo;
                    }
                }
                
            }
            if (Math.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Vector3 verticalMoveTo = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                if(!Physics2D.OverlapCircle(movePoint.position + verticalMoveTo, 0.2f, whatStopsMovement))
                {
                    Collider2D hit =
                        Physics2D.OverlapCircle(movePoint.position + verticalMoveTo, 0.2f, movableObjects);
                    if (hit && hit.GetComponent<Movable>().MoveMe(verticalMoveTo))
                    {
                        movePoint.position += verticalMoveTo;
                    }
                }
            }
            
            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }
}
