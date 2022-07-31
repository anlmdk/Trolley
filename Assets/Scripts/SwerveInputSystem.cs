using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    public SwerveMovement swerve;

    private float firstPositionX, firstPositionY;
    private float directionX, directionY;

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
            firstPositionX = Input.mousePosition.x;
            firstPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            directionX = Input.mousePosition.x - firstPositionX;
            firstPositionX = Input.mousePosition.x;
            directionY = Input.mousePosition.y - firstPositionY;
            firstPositionY = Input.mousePosition.y;

            if(directionY > 100)
            {
                swerve.Shoot();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            directionX = 0f;
            directionY = 0f;
        }
    }
}
