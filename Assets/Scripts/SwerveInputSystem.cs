using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float lastPositionX, lastPositionY;
    private float directionX , directionY;

    public float DirectionX => directionX;
    public float DirectionY => directionY;

    void Update()
    {
        Swerve();
    }
    public void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPositionX = Input.mousePosition.x;
            lastPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            directionX = Input.mousePosition.x - lastPositionX;
            lastPositionX = Input.mousePosition.x;

            directionY = Input.mousePosition.y - lastPositionY;
            lastPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            directionX = 0f;
            directionY = 0f;
        }
    }
}
