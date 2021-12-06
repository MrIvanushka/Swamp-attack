using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Bullet
{

    private void Start()
    {
        StartCoroutine(LaserExisting());
    }

    private void Update()
    {
        
    }

    private IEnumerator LaserExisting()
    {
        for(float scale = 0; scale < 1; scale += 0.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
            yield return null;
        }
        for (float scale = 1; scale > 0; scale -= 0.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
            yield return null;
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(Damage);
    }
}
