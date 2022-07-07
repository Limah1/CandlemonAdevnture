using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour, ITakeDamage
{
    private int health = 5;
    PolygonCollider2D bodyCollider;

    public void TakeDamage(int damage){
        health -= damage;
        Die();
    }

    private void Die(){
        if(health<=0){
            Destroy(gameObject);
        }
    }
    private void Awake() {
        bodyCollider = GetComponent<PolygonCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //TakeDamage(1);
    }

}
