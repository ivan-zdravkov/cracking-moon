using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 10f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallDistance;
    bool hasStarted;

    AudioSource myAudioSource;

    void Start()
    {
        this.paddleToBallDistance = this.transform.position - paddle.transform.position;
        this.hasStarted = false;

        this.myAudioSource = this.GetComponent<AudioSource>();
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                x: Random.Range(-this.xPush, this.xPush),
                y: yPush
            );

            this.hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.hasStarted)
        {
            AudioClip clip = this.ballSounds[Random.Range(0, this.ballSounds.Length - 1)];

            this.myAudioSource.PlayOneShot(clip);
        }
    }
}