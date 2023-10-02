using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHP = 10;
    private int currentHP;

    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            currentHP -= damage;
        }
    }
}
