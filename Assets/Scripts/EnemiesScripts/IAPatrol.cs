using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrol : MonoBehaviour
{

    public float speed;
    public float groundDistance;
    public float rayRange=6f;
    public Transform groundCheck;
    public Transform playerCheck;
    public Transform firePoint;
    public LayerMask playerLayer;
    bool isRight= false;
    bool canPatrol = true;

    [SerializeField] BubbleScript bubbleClass;
    [SerializeField] GameObject bubbleGameObject;
    [SerializeField] GameObject []bubbleArray;
    [SerializeField] int ammoAmmount = 3;
     
  
    private void FixedUpdate() {
       if(!canPatrol){
                Shoot();
       } 
       else{
        Patrol();
       }
        OnShootCheck();
    }

  private void Start() {
    for(int i =0;i <=bubbleArray.Length;i++){
        bubbleArray[i] = bubbleGameObject;
    }
    bubbleClass = FindObjectOfType<BubbleScript>();
  }
    void Patrol(){
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position,Vector2.down,groundDistance);
        if(ground.collider == false){
            if(isRight==false){
                transform.eulerAngles = new Vector3(0,0,0);
                isRight=true;
            }
            else{
                transform.eulerAngles = new Vector3(0,180,0);
                isRight=false;
            }
        }
    }

    void OnShootCheck(){
            RaycastHit2D hitPlayer = Physics2D.Raycast(playerCheck.position,Vector2.left,rayRange,playerLayer);    
            Debug.DrawRay(playerCheck.position,Vector2.left*rayRange,Color.green); 
            if(hitPlayer.collider==false){
                canPatrol = true;
            }else{
                canPatrol = false;
            }                                      
    }

    void Shoot(){
        Debug.Log("estou atirando");
        Instantiate(bubbleClass,firePoint.position,transform.rotation);
        ammoAmmount--;
    }
}   
