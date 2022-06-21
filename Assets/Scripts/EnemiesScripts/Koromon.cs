using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koromon : MonoBehaviour
{
 
    private BoxCollider2D bodyCollider;
    [SerializeField]
    private int life = 3;
    private void Start() {
        bodyCollider = GetComponent<BoxCollider2D>();
    }       

    private void OnCollisionEnter2D(Collision2D other) {
        
        life--;
        if(life <=0){
            FindObjectOfType<DataManager>().addData();
            Destroy(gameObject);
        }
    }

}

   

