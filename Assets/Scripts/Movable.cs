using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private float moveSpeed = 5f;

    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask whatStopsMovement;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    public bool MoveMe(Vector3 direction)
    {
        if (!Physics2D.OverlapCircle(movePoint.position + direction, 0.2f, whatStopsMovement))
        {
            movePoint.position += direction;
            return true;
        }

        return false;
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        /*if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            
        }*/
    }
}
