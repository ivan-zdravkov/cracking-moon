using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    Level level;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(this.breakSound, this.transform.position);

        Destroy(this.gameObject);

        this.level.BlockDestroyed();
    }
}
