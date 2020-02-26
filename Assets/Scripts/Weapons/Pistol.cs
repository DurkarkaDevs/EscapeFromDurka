using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{
    [Header("Specs")]
    public int ammo_in_clip = 2;
    [Range(1, 10)]
    public int per_shot_amount = 1;
    public int clips = 10;
    public float reload_time = 2.0f;
    public float timeBetweenShots = 2.5f;

    [Header("In-Game constants")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private int current_ammo_count = 0;
    private float current_time_between_shots = 0;
    // Start is called before the first frame update
    void Start()
    {
        current_ammo_count = ammo_in_clip;        
    }

    // Update is called once per frame
    void Update()
    {
        //RotateToCursor();
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
        current_time_between_shots -= Time.deltaTime;   
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reload_time);
        clips--;
        current_ammo_count = ammo_in_clip;
    }

    void Shoot()
    {
        if (current_time_between_shots <= 0)
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            current_time_between_shots = timeBetweenShots;
        }
    }
}
