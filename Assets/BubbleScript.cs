using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    Rigidbody2D rb;
    float speed =10f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

  private void Update() {
    rb.velocity = new Vector2(-speed,0f);
  }
    private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.tag=="Player"){
         Destroy(gameObject);
      } 
       
    }
    
}
