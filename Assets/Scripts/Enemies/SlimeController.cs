using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed;
    public Transform rightLimit;
    public Transform leftLimit;
    private int slimeDirection = -1;
    public bool rightFace = true;
    public float rightDis;
    public float leftDis;

    public BoxCollider2D slimeCol;
    public Rigidbody2D slimeRid;
    public bool checkGround = false;
    public LayerMask playerLayerMask;
    public Rigidbody2D playerRid;
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * slimeDirection * Time.deltaTime);
        CheckLimit();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, playerLayerMask);
        Debug.DrawRay(transform.position, Vector2.up, Color.green);
        if(hit.collider != null)
        {
            if(playerRid.velocity.y < -0.1 && hit.collider.gameObject.name == "Player")
            {
                Destroy(gameObject);
            }
            else
            {
                if (playerControllerScript.canTakeDamage && (playerControllerScript.isOnBox || playerControllerScript.isGrounded))
                {
                    playerControllerScript.Shrink();
                }
            }
        }
        
    }
    private void CheckLimit()
    {
        rightDis = Vector2.Distance(transform.position, rightLimit.position);
        leftDis = Vector2.Distance(transform.position, leftLimit.position);
        if (rightDis < 0.8 || leftDis < 0.8)
        {
            FlipFace();
        }
    }
    private void FlipFace()
    {
        slimeDirection *= -1;
        rightFace = !rightFace;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slimeCol.isTrigger = true;
            if(slimeRid.velocity.y == 0)
            {
                slimeRid.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            checkGround = true;
            slimeRid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slimeCol.isTrigger = false;
            if (!checkGround)
            {
                slimeRid.constraints = RigidbodyConstraints2D.None;
                slimeRid.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
    }

}

