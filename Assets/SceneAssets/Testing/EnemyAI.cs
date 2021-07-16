using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform startMarker, endMarker;
    public Transform[] waypoints;
    float startTime;
    float journeyLength;
    public float speed = 10f;
    public bool canComeBack;

    int currentStartPoint;
    void Start()
    {
        canComeBack = true;
        currentStartPoint = 0;
        SetPoints();
    }
    void SetPoints()
    {
        startMarker = waypoints[currentStartPoint];
        if(currentStartPoint + 1 < waypoints.Length)
            endMarker = waypoints[currentStartPoint + 1];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        if (fracJourney >= 1f && currentStartPoint + 1 < waypoints.Length)
        {
            currentStartPoint++;
            SetPoints();
        }
        else if(currentStartPoint + 1 == waypoints.Length )
        {
            currentStartPoint = 0;
            System.Array.Reverse(waypoints);
            SetPoints();
        }
        else
        {
            return;
        }
    }



}
