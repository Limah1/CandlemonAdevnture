using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovScript : MonoBehaviour
{
    Vector2 movInput;
    float playerSpeed=10f;
    [SerializeField]  private float jumpSpeed=25f;
    [SerializeField]   private float boosterJump = 5f;
    Rigidbody2D rbPlayer;
    CapsuleCollider2D feetCollider;
    [SerializeField]
    private InputActionReference actionModifier;

    bool canDash = true;
    bool isDashing;
    float dashingPower;
    float dashingTime=0.2f;
    float dashingCooldown=1f;

    void Awake(){
        feetCollider = GetComponent<CapsuleCollider2D>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    void OnMove(InputValue value){
        movInput = value.Get<Vector2>();
    }

    private void OnEnable() {
        actionModifier.action.Enable();
    }
    private void OnDisable() {
        actionModifier.action.Disable();
    }
    void MovePlayer(){
        Vector2 playerVelocity = new Vector2(movInput.x*playerSpeed,rbPlayer.velocity.y);
        rbPlayer.velocity = playerVelocity;
    }
    
     void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(rbPlayer.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
             transform.localScale = new Vector2 (-Mathf.Sign(rbPlayer.velocity.x),1f);
        }
    }

    void Update(){
         if(isDashing){
            return;
        }
        MovePlayer();
        FlipSprite();
        OnFireJump();

    }
    void FixedUpdate(){ 
        if(isDashing){
            return;
        } 
    }

    void OnJump(InputValue value){
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))){ return;}
        if(value.isPressed){
            rbPlayer.velocity += new Vector2(0f,jumpSpeed);
        }

    }
    void OnFireJump(){
      actionModifier.action.started +=_=>{ };   
      actionModifier.action.performed += _=>{
         rbPlayer.velocity += new Vector2(0f,boosterJump);
        };
        actionModifier.action.canceled += _=>{};
    }
            

    private IEnumerator Dash(){
        dashingPower = 30f;
        canDash = false;
        isDashing= true;
        float originalGravity = rbPlayer.gravityScale;
        rbPlayer.gravityScale = 0f;
        rbPlayer.velocity = new Vector2(-transform.localScale.x*dashingPower,0f);
        yield return new WaitForSeconds(dashingTime);
        rbPlayer.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash=true;
    }
    
    void OnDash(InputValue value){
        if(value.isPressed && canDash){
            StartCoroutine(Dash());
        }
    }
}