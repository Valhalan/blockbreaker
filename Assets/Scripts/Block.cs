using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip blockDestroySound;

    //cached references
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockDestroySound, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        Destroy(gameObject);
        level.BlockDestoyed();
    }
}
