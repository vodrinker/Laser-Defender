using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 direction;
    private Rigidbody2D myRigidbody2d;
    private float moveSpeed;
    private Ship player;
    private float xMax, xMin, yMax, yMin;


    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Ship>();
        SetXYMinMax();
    }

    void Update()
    {
        moveSpeed = player.GetMoveSpeed();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < xMax && mousePosition.x > xMin && mousePosition.y < yMax && mousePosition.y > yMin)
        {
            direction = (mousePosition - transform.position).normalized;
            myRigidbody2d.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            myRigidbody2d.velocity = Vector2.zero;
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
