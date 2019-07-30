using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] float xPush = 10f;
    [SerializeField] float yPush = 12f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    Vector2 paddleToBallDistance;
    bool hasStarted;

    Level level;
    Paddle paddle;
    Rigidbody2D myRigidBody;
    AudioSource myAudioSource;

    void Start()
    {
        this.hasStarted = false;

        this.paddle = FindObjectOfType<Paddle>();
        this.level = FindObjectOfType<Level>();
        this.myRigidBody = this.GetComponent<Rigidbody2D>();
        this.myAudioSource = this.GetComponent<AudioSource>();

        this.paddleToBallDistance = this.transform.position - this.paddle.transform.position;

        this.level.CountBalls();
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
            this.myRigidBody.velocity = new Vector2(
                x: UnityEngine.Random.Range(-this.xPush, this.xPush),
                y: yPush
            );

            this.hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            x: UnityEngine.Random.Range(0, this.randomFactor),
            y: UnityEngine.Random.Range(0, this.randomFactor)
        );

        if (this.hasStarted)
        {
            AudioClip clip = this.ballSounds[UnityEngine.Random.Range(0, this.ballSounds.Length - 1)];

            this.myAudioSource.PlayOneShot(clip);

            if (SlowerThanSpeed(velocityTweak))
                IncreaseVelocity(velocityTweak);
            else if (FasterThanTwiceTheSpeed(velocityTweak))
                DecreaseVelocity(velocityTweak);
            else
                RandomVelocity(velocityTweak);
        }
    }

    private bool SlowerThanSpeed(Vector2 tweaked)
    {
        Vector2 original = this.myRigidBody.velocity;

        return ((original.x + tweaked.x) * (original.x + tweaked.x)) +
            ((original.y + tweaked.y) * (original.y + tweaked.y))
             < (this.yPush * this.yPush);
    }

    private bool FasterThanTwiceTheSpeed(Vector2 tweaked)
    {
        Vector2 original = this.myRigidBody.velocity;

        return ((original.x + tweaked.x) * (original.x + tweaked.x)) + 
            ((original.y + tweaked.y) * (original.y + tweaked.y)) 
             > ((this.yPush * 2) * (this.yPush * 2));
    }

    private void IncreaseVelocity(Vector2 velocityTweak)
    {
        float x = Math.Abs(velocityTweak.x);
        float y = Math.Abs(velocityTweak.y);

        if (this.myRigidBody.velocity.x <= 0)
            x *= -1;

        if (this.myRigidBody.velocity.y <= 0)
            y *= -1;

        this.myRigidBody.velocity += new Vector2(x, y);
    }

    private void DecreaseVelocity(Vector2 velocityTweak)
    {
        float x = Math.Abs(velocityTweak.x);
        float y = Math.Abs(velocityTweak.y);

        if (this.myRigidBody.velocity.x > 0)
            x *= -1;

        if (this.myRigidBody.velocity.y > 0)
            y *= -1;

        this.myRigidBody.velocity += new Vector2(x, y);
    }

    private void RandomVelocity(Vector2 velocityTweak)
    {
        this.myRigidBody.velocity += velocityTweak;
    }
}