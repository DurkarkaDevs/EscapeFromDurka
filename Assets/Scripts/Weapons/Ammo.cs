using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Specs")]
    public float damage = 0.1f;
    public float speed = 20f;

    [Header("Optimizations")]
    public float lifetime = 20f;

    private Rigidbody2D rigidBody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        rigidBody2d.velocity = transform.right * speed;
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EntityBaseClass entity = hitInfo.GetComponent<EntityBaseClass>();
        if(entity != null)
            entity.TakeDamage(damage);
        Destroy(gameObject);
    }
}
