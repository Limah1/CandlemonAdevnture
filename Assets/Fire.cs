using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  Rigidbody2D rbFire;
  float fireSpeed = 20f;
  float xSpeed;
  PlayerMovScript playerScript;

  PolygonCollider2D body;
  


void Awake(){
    rbFire = GetComponent<Rigidbody2D>();
    playerScript = FindObjectOfType<PlayerMovScript>();
    body = GetComponent<PolygonCollider2D>();
    xSpeed = playerScript.transform.localScale.x*fireSpeed;
}

void Update(){
    rbFire.velocity = new Vector2(-xSpeed,0f);
    FlipSprite();
}


void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(rbFire.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
             transform.localScale = new Vector2 (Mathf.Sign(rbFire.velocity.x),1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }


}
