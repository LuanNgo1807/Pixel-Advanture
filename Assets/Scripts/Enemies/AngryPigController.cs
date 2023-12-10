using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPigController : MonoBehaviour
{
    public float speed;
    public Transform rightLimit;
    public Transform leftLimit;
    private int pigDirection = -1;
    public bool rightFace = true;
    public float rightDis;
    public float leftDis;

    public LayerMask playerLayerMask;
    public PlayerController playerControllerScript;
    public Rigidbody2D playerRid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * pigDirection * Time.deltaTime * speed);
        CheckLimit();

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.5f), Vector2.up, 1f, playerLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.5f), Vector2.up, Color.green);
        if(hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            Vector2 hitPoint = hit.point;
            if(hitPoint.y > transform.position.y && !playerControllerScript.isGrounded && playerRid.velocity.y < -0.1)
            {
                Destroy(gameObject);
            }
            else
            {
                if (playerControllerScript.canTakeDamage)
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
        if (rightDis < 0.8f || leftDis < 0.8f)
        {
            FlipFace();
        }
    }
    private void FlipFace()
    {
        pigDirection *= -1;
        rightFace = !rightFace;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
