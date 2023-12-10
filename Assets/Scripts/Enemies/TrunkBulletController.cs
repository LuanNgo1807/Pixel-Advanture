using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletController : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1 * Time.deltaTime * speed,0));
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && playerControllerScript.canTakeDamage)
        {
            playerControllerScript.Shrink();
            Destroy(gameObject);
        }
    }
}
