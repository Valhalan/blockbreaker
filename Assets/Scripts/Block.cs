using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // configurations params
    [SerializeField] AudioClip blockDestroySound;
    [SerializeField] GameObject blockParticleEffect;
    [SerializeField] Sprite[] hitSprites;

    //cached references
    Level level;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for Debug purposes

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from Array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestoyed();
        TriggerParticleEffect();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(blockDestroySound, new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }

    private void TriggerParticleEffect()
    {
        GameObject particles = Instantiate(blockParticleEffect, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }

}
