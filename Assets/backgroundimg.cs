using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundimg : MonoBehaviour
{
    private float startPos, length;
    public float scrollSpeed = 2f; 

    private void Start()
    {
        
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
       
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

       
        if (transform.position.x <= startPos - length)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
    }
}