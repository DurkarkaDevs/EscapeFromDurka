using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBaseClass : MonoBehaviour
{
    [Header("Stats")]
    public float hp = 2.5f;
    public float movespeed = 10f;
    public float jumpforce = 10f;

    protected bool facing_right = false;
    


    public void TakeDamage(float damage_amount)
    {

    }

    protected void Flip()
    {
        facing_right = !facing_right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
