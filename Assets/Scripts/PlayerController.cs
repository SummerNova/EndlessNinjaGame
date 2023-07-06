using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D RB;
    public float jumpSTR;
    public float jumpTimeCounter;
    public Collider2D coll;
    float jumptimer = 0.5f;
    bool peak = false;
    bool isJumping = false;
    bool isFalling = false;

    private RaycastHit2D ground;
    public float extraHeight = 0.25f;
    public LayerMask whatIsGround;

    public Animator anim;

    public float dashDuration = 0.1f;
    public float dashSTR = 5f;
    public float dashTimer = 0.1f;
    public bool isDashing = false;
    public bool dashReset = true;
    public ParticleSystem partSys;

    public PlayerAudio audioControl;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetMouseButtonDown(1) && dashTimer > 0 && !dashReset){
            Debug.Log("happened");
            audioControl.Dash();
            isDashing = true;
            dashTimer -= Time.deltaTime;
            RB.velocity = new Vector2(dashSTR,0);
            dashReset = true;
            partSys.Play();

        }
        else if (dashTimer > 0 && isDashing){
            dashTimer -= Time.deltaTime;
            RB.velocity = new Vector2(dashSTR,0);
        }
        else {
            isDashing = false;
            partSys.Stop();
        }
        
        if (dashReset&&!isDashing){
            dashReset = !IsGrounded();
        }
        else if (!isDashing){
            dashTimer = dashDuration;
        }


        if (!isDashing)
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0){
                anim.SetBool("isrunning",false);
            }
            else{
                anim.SetBool("isrunning",true);
            }
            RB.velocity = new Vector2(horizontal*speed,RB.velocity.y);

            if (Input.GetKeyDown(KeyCode.W) && IsGrounded()){
                audioControl.Jump();
                isJumping = true;
                jumpTimeCounter = jumptimer;
                RB.velocity = new Vector2(RB.velocity.x,jumpSTR);
                anim.SetBool("isJumping",true);
                
                
                
            }

            if (Input.GetKey(KeyCode.W)){
                if (jumpTimeCounter > 0 && isJumping){
                    RB.velocity = new Vector2(RB.velocity.x,jumpSTR);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else {
                    isJumping = false;
                }
                
            }

            if (Input.GetKeyUp(KeyCode.W)){

                isJumping = false;
                anim.SetBool("isJumping",false);
            }      
        }

    }

    private bool IsGrounded(){
        ground = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, whatIsGround);

        if (ground.collider != null){
            return true;
        }
        else {
            return false;
        }
    }
}
