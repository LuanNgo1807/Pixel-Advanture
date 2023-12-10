using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkController : MonoBehaviour
{
    public GameObject trunkBullet;
    public LayerMask playerLayerMask;
    public Animator trunkAnim;
    public PlayerController playerControllerScript;
    public Rigidbody2D playerRid;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 2f, playerLayerMask);
        Debug.DrawRay(transform.position, Vector2.up, Color.green);
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.name == "Player" && playerRid.velocity.y < -0.1f)
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
    private void Attack()
    {
        trunkAnim.SetTrigger("attack");
        StartCoroutine(WaitBullet());
        
    }
    IEnumerator WaitBullet()
    {
        Vector3 offset = new Vector3(0, -0.25f, 0);
        yield return new WaitForSeconds(1f);
        Instantiate(trunkBullet, transform.position + offset, Quaternion.identity);
    }
}
