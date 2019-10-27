using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 2;
    float totalHealth;
    public GameObject soundSource;

    private void Start()
    {
        totalHealth = currentHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth --;
        if(currentHealth <= 0 && !GetComponent<EnemyFollowing>().isDead)
        {
            GetComponent<EnemyFollowing>().SpawnGore();
            GetComponent<EnemyFollowing>().SpawnGore();
            GetComponent<EnemyFollowing>().isDead = true;
            if (soundSource)
            {
                Instantiate(soundSource);
            }
            Destroy(gameObject);
        }
    }
}
