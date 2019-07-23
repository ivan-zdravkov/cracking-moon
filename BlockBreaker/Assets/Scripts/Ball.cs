using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;

    Vector2 paddleToBallDistance;
    bool hasStarted;

    void Start()
    {
        this.paddleToBallDistance = this.transform.position - paddle.transform.position;
        this.hasStarted = false;
    }

    void Update()
    {
        if (!this.hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(
                    x: paddle.transform.position.x,
                    y: paddle.transform.position.y
                );

        this.transform.position = paddlePosition + this.paddleToBallDistance;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton((int)MouseButton.LeftMouse))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(x: xPush, y: yPush);

            this.hasStarted = true;
        }
    }
}