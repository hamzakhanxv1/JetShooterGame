using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    public int scoreValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        Level.instance.AddDestructable();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 19.42f)
        {
            canBeDestroyed = true;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        bulletscript bulletscript = collision.GetComponent<bulletscript>();
        if (bulletscript != null)
        {
            if (!bulletscript.isEnemy)
            {
                Level.instance.AddScore(scoreValue);

                Destroy(gameObject);
                Destroy(bulletscript.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        Level.instance.RemoveDestructable();
    }
}
