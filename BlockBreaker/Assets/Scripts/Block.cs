using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
 
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.gameStatus = FindObjectOfType<GameSession>();

        this.level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        this.PlayDestroySFX();
        this.TriggerSparklesVFX();

        Destroy(this.gameObject);

        this.gameStatus.AddToScore();
        this.level.BlockDestroyed();
    }

    private void PlayDestroySFX()
    {
        AudioSource.PlayClipAtPoint(this.breakSound, this.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparcles = Instantiate(this.sparklesVFX, this.transform.position, this.transform.rotation);

        Destroy(sparcles, 2);
    }
}
