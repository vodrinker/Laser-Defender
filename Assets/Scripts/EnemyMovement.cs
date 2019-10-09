using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private Rigidbody2D myRigidbody2d;
    private float moveSpeed;
    private float xyMovementMultiplier = 2;
    [SerializeField] private Ship thisShip;
    //private float xMax, xMin, yMax, yMin;

    private void OnEnable()
    {
        //SetXYMinMax();
        moveSpeed = thisShip.GetMoveSpeed();
        direction = xyMovementMultiplier * Vector3.right + Vector3.down;
        myRigidbody2d.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed);
    }


    //void Update()
    //{
    //    //CalculateDirection();
    //    //
    //    //myRigidbody2d.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed);
    //}

    private void Disapear()
    {
        Destroy(gameObject);
    }


    ////not using it in this version
    //void CalculateDirection()
    //{
    //    if (myRigidbody2d.velocity.x > 0 && transform.position.x > xMax)
    //    {
    //        direction = 2 * Vector3.left + Vector3.down;
    //    }
    //    if (myRigidbody2d.velocity.x < 0 && transform.position.x < xMin)
    //    {
    //        direction = 2 * Vector3.right + Vector3.down;
    //    }
    //    if (gameObject.transform.position.y < yMin-1)
    //    {
    //        Disapear();
    //    }
    //}

    ////not using it in this version
    //private void SetXYMinMax()
    //{
    //    Camera camera = Camera.main;
    //    xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    //    xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    //    yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    //    yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SideWalls")
        {
            direction = new Vector3(direction.x * -1, direction.y);
            myRigidbody2d.velocity = new Vector3(direction.x, direction.y);
        }
    }
}
