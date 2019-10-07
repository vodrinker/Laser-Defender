using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody2D myRigidbody2d;
    private float moveSpeed;
    private Ship thisShip;
    private float xMax, xMin, yMax, yMin;

    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        thisShip = gameObject.GetComponent<Ship>();
        SetXYMinMax();
        direction = 2 * Vector3.right + Vector3.down;
    }


    void Update()
    {
        CalculateDirection();
        moveSpeed = thisShip.GetMoveSpeed();
        myRigidbody2d.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    private void Disapear()
    {
        Destroy(gameObject);
    }

    void CalculateDirection()
    {
        if (myRigidbody2d.velocity.x > 0 && gameObject.transform.position.x > xMax)
        {
            direction = 2 * Vector3.left + Vector3.down;
        }
        if (myRigidbody2d.velocity.x < 0 && gameObject.transform.position.x < xMin)
        {
            direction = 2 * Vector3.right + Vector3.down;
        }
        if (gameObject.transform.position.y < yMin-1)
        {
            Disapear();
        }
    }

    private void SetXYMinMax()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}
