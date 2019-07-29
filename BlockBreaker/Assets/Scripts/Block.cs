using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;
        
    Level level;
    GameSession gameSession;

    int timesHit = 0;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.gameSession = FindObjectOfType<GameSession>();

        if (this.tag == "Breakable")
            this.level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Breakable")
            HandleHit();
    }

    private void HandleHit()
    {
        this.timesHit++;

        if (this.timesHit >= this.hitSprites.Length + 1)
            DestroyBlock();
        else
            ShowNextHitSprite();
    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = this.hitSprites[timesHit];
    }

    private void DestroyBlock()
    {
        this.PlayBreakSFX();
        this.TriggerSparklesVFX();

        Destroy(this.gameObject);

        this.gameSession.AddToScore();
        this.level.BlockDestroyed();
    }

    private void PlayBreakSFX()
    {
        AudioSource.PlayClipAtPoint(this.breakSFX, this.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparcles = Instantiate(this.sparklesVFX, this.transform.position, this.transform.rotation);

        Destroy(sparcles, 2);
    }
}
