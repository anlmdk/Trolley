using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float lastPositionX;
    private float direction;

    public float Direction => direction;

    void Update()
    {
        Swerve();
    }
    public void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            direction = Input.mousePosition.x - lastPositionX;
            lastPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            direction = 0f;
        }
    }
}
