using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private GameObject hitEffect;
    private float currentHealth;

    private void Awake() {
        currentHealth = maxHealth;
    }

    public void GetHit(float damage, Vector3 hitPosition, Vector3 hitNormal){
        Quaternion impactRotation = Quaternion.LookRotation(hitNormal);
        GameObject impact = Instantiate(hitEffect, hitPosition, impactRotation);
        Destroy(impact, 0.5f);
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(impact);
            Die();
        }
        else{
            print(name + " has " + currentHealth + " health left");
        }
    }

    private void Die(){
        print(name + " just died!");
        Destroy(gameObject);
    }
}
