using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    new BoxCollider2D collider2D;
    private void Start() {
        collider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag=="Player"){
            FindObjectOfType<DataManager>().addData();
            Destroy(gameObject);
         }

    }


}
