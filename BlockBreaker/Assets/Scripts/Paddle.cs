using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] AudioClip bounceSound;

    void Update()
    {
        this.transform.position = new Vector3(
            x: Mathf.Clamp(
                value: Input.mousePosition.x / Screen.width * this.screenWidthInUnits,
                min: 0f,
                max: this.screenWidthInUnits
            ),
            y: this.transform.position.y,
            z: 1
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(this.bounceSound, this.transform.position);
    }
}
