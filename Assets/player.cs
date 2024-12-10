using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Gun[] guns;
    AudioSource shootSound;

    float moveSpeed = 3f;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;

    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        shootSound = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        //for speed i set the button shift
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        shoot = Input.GetKeyDown(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();

            }
            if (shootSound != null)//for sound i set
            {
                shootSound.Play();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        // for speeeding
        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedUp)
        {
            moveAmount *= 3;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }
        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x += moveAmount;
        }
        pos += move;
        //i set this for boundry
        if (pos.x <= -1.75f)
        {
            pos.x = -1.75f;
        }
        if (pos.x >= 18.45f)
        {
            pos.x = 18.45f;
        }
        if (pos.y <= 1.18f)
        {
            pos.y = 1.18f;
        }
        if (pos.y >= 9.15f)
        {
            pos.y = 9.15f;
        }


        transform.position = pos;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulletscript bullet = collision.GetComponent<bulletscript>();
        if(bullet != null)
        {
            if(bullet!=null)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
        Destructable destructable = collision.GetComponent<Destructable>();
        if(destructable!= null)
        {
            Destroy(gameObject);
            Destroy(destructable.gameObject);

        }
    }


}