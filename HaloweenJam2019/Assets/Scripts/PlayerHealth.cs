using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 10;
    public Image healthBar;
    float totalHealth;
    bool isAlive = true;

    private void Start()
    {
        totalHealth = currentHealth;
    }

    public void Hurt(float damageAmount)
    {
        if (isAlive)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                GameObject temp = Instantiate(new GameObject(), transform.position, transform.rotation);
                transform.parent = temp.transform;
                //GetComponent<Animator>().SetTrigger("Death");
                isAlive = false;
                GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            }
            healthBar.fillAmount = (1 / totalHealth) * currentHealth;
        }
    }
}