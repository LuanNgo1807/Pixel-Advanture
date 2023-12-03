using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    [Header("Movement")]
    public float speed;
    public bool faceRight;
    public float horizontal;
    public bool mobileButton = false;

    [Header("Jump")]
    public bool isGrounded;
    public float jumpForce;
    public bool mobileJump = false;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("OnBox")]
    public LayerMask boxLayer;
    public bool isOnBox;

    [Header("OnFireTrapOff")]
    public LayerMask FireTrapOffLayer;
    public bool isOnFireTrapOff;
    public bool flameCollision;
    public LayerMask flame;
    public Transform onFire;
    public bool canTakeDamage;

    [Header("Player Hitted")]
    public SpriteRenderer playerSprite;
    private bool isInvulnerable = false;
    public float invulnerabilityTime = 2f;
    private PlayerHealth health;

    [Header("OnFan")]
    public bool onFanOff;

    private GameObject[] fire;
    
    public GameObject startPoint;

    [Header("Sound")]
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.transform.position;
        playerRb = this.GetComponent<Rigidbody2D>();
        playerAnim = this.GetComponent<Animator>();
        playerRb.gravityScale = 10f;
        fire = GameObject.FindGameObjectsWithTag("Fire");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mobileButton)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isOnBox || isOnFireTrapOff))
            {
                SetJump();
            }
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position,new Vector2(1.2f,1), 0,groundLayer);
        isOnBox = Physics2D.OverlapBox(groundCheck.position,new Vector2(1.2f,1), 0,boxLayer);
        isOnFireTrapOff = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.2f, 1), 0, FireTrapOffLayer);
        flameCollision = Physics2D.OverlapBox(onFire.position, new Vector2(1.5f, 1), 0, flame);
        SetJumpAnimation();

        
    }
    public void SetJump()
    {
        Jump();
        playerAudio.PlayOneShot(jumpSound, 0.5f);
    }
    private void FixedUpdate()
    {
        if (!mobileButton)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        /*playerRb.constraints = RigidbodyConstraints2D.FreezePositionY;*/

        Move();
        Flip();
        if(playerRb.velocity.x != 0)
        {
            playerAnim.SetBool("Run", true);
        }
        else if(playerRb.velocity.x == 0)
        {
            playerAnim.SetBool("Run", false);
        }
    }
    private void Move()
    {
        playerRb.velocity = new Vector2(speed * horizontal, playerRb.velocity.y);
    }
    private void Flip()
    {
        if((horizontal > 0 && faceRight) || (horizontal < 0 && !faceRight))
        {
            faceRight = !faceRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    private void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }
    private void SetJumpAnimation()
    {
        if (isGrounded || isOnBox || isOnFireTrapOff || onFanOff)
        {
            playerAnim.SetBool("isJumping", false);
        }
        else if (!isGrounded && !isOnBox)
        {
            playerAnim.SetBool("isJumping", true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(1.2f, 1));
        Gizmos.DrawWireCube(onFire.position, new Vector2(1.5f, 1));
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike" && !isInvulnerable && canTakeDamage)
        {
            StartCoroutine(BlinkEffect());
            canTakeDamage = false;
            health.TakeDamage(1);
            StartCoroutine(ResetDamageCooldown());
        }
        else if (collision.gameObject.tag == "Fire" && flameCollision && canTakeDamage)
        {
            StartCoroutine(BlinkEffect());
            health.TakeDamage(1);
            canTakeDamage = false;
            StartCoroutine(ResetDamageCooldown());
            
        }
    }

    IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
    }



    IEnumerator BlinkEffect()
    {
        isInvulnerable = true;
        // Hiệu ứng nháy nháy trong thời gian nhất định
        float elapsedTime = 0f;
        while (elapsedTime < invulnerabilityTime)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f); // Thời gian nhấp nháy
            elapsedTime += 0.1f;
        }

        // Kết thúc hiệu ứng nháy nháy
        GetComponent<SpriteRenderer>().enabled = true;
        isInvulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {

            FanController fanScripts = collision.gameObject.GetComponent<FanController>();

            if(fanScripts != null)
            {
                if (fanScripts.fanOn)
                {
                    playerAudio.PlayOneShot(jumpSound, 1.0f);
                    playerRb.AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
                    onFanOff = false;
                }
                else if (fanScripts.fanOn == false)
                {
                    onFanOff = true;
                }
            }
        }
        //if trigger with the saw, player takes damage
        else if (collision.gameObject.CompareTag("Saw") && canTakeDamage)
        {
            StartCoroutine(BlinkEffect());
            health.TakeDamage(1);
            canTakeDamage = false;
            StartCoroutine(ResetDamageCooldown());
        }
    }
    
}
