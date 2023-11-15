using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] AudioClip bounceSound;

    GameSession gameSession;
    Ball[] balls;

    void Start()
    {
        this.gameSession = FindObjectOfType<GameSession>();
        this.balls = FindObjectsOfType<Ball>();
    }

    void Update()
    {
        Ball firstBall = this.balls.FirstOrDefault();
        Ball lowestBall = this.balls
            .Where(x => x != null && x.isActiveAndEnabled && x.transform.position.y > 0)
            .OrderBy(x => x.transform.position.y)
            .FirstOrDefault();

        Ball ball = lowestBall;

        if (ball != null)
        {
            float x = this.gameSession.IsAutoPlayEnabled && ball.HasStarted ?
                ball.transform.position.x :
                Input.mousePosition.x / Screen.width * this.screenWidthInUnits;

            this.transform.position = new Vector3(
                x: Mathf.Clamp(
                    value: x,
                    min: 0f,
                    max: this.screenWidthInUnits
                ),
                y: this.transform.position.y,
                z: 1
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(this.bounceSound, this.transform.position);
    }
}
