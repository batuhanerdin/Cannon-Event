using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjectDestroy : MonoBehaviour
{
    public GameObject animObject;
    private GameObject gameObjectanim;
    private Animator animator;
    public void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Planet") 
            || collision.gameObject.CompareTag("Checkpoint") || collision.gameObject.CompareTag("Checkpoint") 
            || collision.gameObject.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
            gameObjectanim = Instantiate(animObject, transform.position, Quaternion.identity);
            Destroy(gameObjectanim, 0.5f);
        }
    }
}
