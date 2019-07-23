using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;

    Vector2 paddleToBallDistance;

    void Start()
    {
        this.paddleToBallDistance = this.transform.position - paddle.transform.position;
    }

    void Update()
    {
        Vector2 paddlePosition = new Vector2(
            x: paddle.transform.position.x,
            y: paddle.transform.position.y
        );

        this.transform.position = paddlePosition + this.paddleToBallDistance;
    }
}
