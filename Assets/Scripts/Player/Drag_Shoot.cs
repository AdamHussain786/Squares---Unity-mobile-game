using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Drag_Shoot : MonoBehaviour
{
    public float power = 10f;
    private Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    //Effects
    LineRenderer lr;
    private Player player;
    private int iterations;
    public ParticleSystem dust;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if ((Input.touchCount > 0 && (iterations < player.swipes)))    //If touch count is greater than 0(Are we touching?)
        {
            Touch touch = Input.GetTouch(0);        //Get the touch so we have some info

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    startPoint = Camera.main.ScreenToWorldPoint(touch.position);
                    startPoint.z = 15;
                    iterations++;
                    break;

                case TouchPhase.Moved:
                    Vector3 currentPoint = cam.ScreenToWorldPoint(touch.position);
                    currentPoint.z = 15;
                    RenderLine(startPoint, currentPoint);
                    break;

                case TouchPhase.Ended:
                    Effects(touch);
                    break;

            }
        }
        else if(player.isGrounded())
        {
            iterations = 0;
            //Debug.Log(iterations);
            //Debug.Log("5 swipes occured");
        }
    }

    void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    void EndLine()
    {
        lr.positionCount = 0;
    }

    void Effects(Touch touch)
    {
        endPoint = cam.ScreenToWorldPoint(touch.position);
        endPoint.z = 15;
        AudioManager.instance.PlaySound("Jump");
        force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode2D.Impulse);
        EndLine();
        dust.Play();
    }
}
