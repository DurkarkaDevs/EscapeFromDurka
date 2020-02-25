using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Specs")]
    public float damage = 0.1f;
    public float lifetime = 10f;
    public float speed = 10f;

    [Header("In-Game Constants")]
    public GameObject deathEffect;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        StartCoroutine(Lifetime());

    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
    



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet") return;
        EntityBaseClass entity = collider.GetComponent<EntityBaseClass>();
        if (deathEffect != null) {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        if(entity != null)
        {
            
            entity.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
