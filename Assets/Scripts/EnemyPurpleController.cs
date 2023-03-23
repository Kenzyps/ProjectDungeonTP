using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPurpleController : MonoBehaviour
{
    [SerializeField] public int life = 2;
    [SerializeField] private SpriteRenderer enemySprite;
    private float damageTime = 0.2f;

    private void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject, 0.2f);
            //enemySprite.color = Color.red;
            
        }


    }
    public void takeDamage(int damage)
    {
        life -= damage;
        StartCoroutine(colorDamageTime());
    }
    private IEnumerator colorDamageTime()
    {
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(damageTime);
        enemySprite.color = Color.white;
    }
}
