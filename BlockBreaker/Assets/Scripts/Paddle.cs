using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16;

    void Update()
    {
        transform.position = new Vector2(
            x: Mathf.Clamp(
                value: Input.mousePosition.x / Screen.width * this.screenWidthInUnits,
                min: 0,
                max: this.screenWidthInUnits
            ),
            y: transform.position.y
        );
    }
}
