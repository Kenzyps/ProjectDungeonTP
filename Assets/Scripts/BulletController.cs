using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
            var inimigo = collision.gameObject.GetComponent<EnemyPurpleController>();
            if (inimigo != null) // verifica se a referência não é nula
            {
                inimigo.takeDamage(1); // chama o método takeDamage do inimigo
            }
        }
    }
}
