using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum swipe_direction
{
    none,
    up,
    down,
    left,
};

public class swipeCTRL : MonoBehaviour
{
    Vector2 StartPosition;
    Vector2 EndPosition;
    Vector2 Direction;
    Vector2 Up = Vector2.up;
    float dot = 0;
    bool pressed = false;

    float BeginTime = 0.0f;
    float timer = 0.0f;
    float delay = 3.0f;

    public swipe_direction GetSwipeDirection()
    {
        swipe_direction dir = swipe_direction.none;

        if (Direction != Vector2.zero)
        {
            dot = Vector2.Dot(Direction, Up);

            if (dot >= 0.5)
            {
                dir = swipe_direction.up;
            }
            if (dot <= -0.5)
            {
                dir = swipe_direction.down;
            }
            if (dot < 0.02 && dot > -0.02)
            {
                dir = swipe_direction.left;
            }
        }

        return dir;
    }

    public bool PressedDown()
    {
        return pressed;
    }

    // Update is called once per frame
    void Update ()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartPosition = touch.position;
                    EndPosition = touch.position;
                    BeginTime = Time.time;
                    break;

                case TouchPhase.Moved:
                    Direction = touch.position - StartPosition;
                    Direction.Normalize();
                    EndPosition = touch.position;

                    break;

                case TouchPhase.Stationary:
                    float EndTime = Time.time;

                    if((EndTime - BeginTime) >= 2.0f)
                    {
                        pressed = true;
                    }

                    break;

                case TouchPhase.Ended:
                    StartPosition = Vector2.zero;
                    EndPosition = Vector2.zero;
                    Direction = Vector2.zero;
                    BeginTime = 0;
                    dot = 0;
                    pressed = false;

                    break;

                case TouchPhase.Canceled:
                    break;
            }
        }
    }
}
