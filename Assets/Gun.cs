using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bulletscript bullet;
    public AudioSource shootingSound;
    Vector2 direction;

   public bool autoshoot = false;
   public float shootIntervalSeconds = 0.5f;
   public  float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

   
    // Start is called before the first frame update
    void Start()
    {
        if (shootingSound == null)
        {
            shootingSound = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        direction = (transform.localRotation * Vector2.right).normalized;

        if (autoshoot)
        {
            if (delayTimer>=shootDelaySeconds)
            {
                if(shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer  += Time.deltaTime;
            }
        }

    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        bulletscript gobulletscript = go.GetComponent<bulletscript>();
        gobulletscript.direction = direction;

        if (shootingSound != null)
        {
            shootingSound.Play();
        }

    }
}
