using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koromon : MonoBehaviour, IDamageable
{
 
    private BoxCollider2D bodyCollider;
    [SerializeField]
    private int life = 3;
    private int damage=1;
    private void Start() {
        bodyCollider = GetComponent<BoxCollider2D>();
    }       

    private void OnTriggerEnter2D(Collider2D other) {
        IDamageable damageable = GetComponent<IDamageable>();
        if(damageable!=null){
            damageable.Damage();
        }
    }

    public void Damage() {
       life-= damage;
       Die();
    }

    private void Die(){
        if(life<=0){
            Destroy(gameObject);
        }
    }
}

   

