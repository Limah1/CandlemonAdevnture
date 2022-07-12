using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour, ITakeDamage
{
    public int health = 5;
    public void TakeDamage(int damage){
        health -= damage;
        Die();
    }

    private void Die(){
        if(health<=0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.IsTouchingLayers(LayerMask.GetMask("Consumable"))){
        return;
       } 
        TakeDamage(1);
    }
    public int GetHealth(){
        return health;
    }
}
