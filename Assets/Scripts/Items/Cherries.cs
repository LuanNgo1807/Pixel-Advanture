using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherries : MonoBehaviour
{
    public Animator cherryAnim;
    public GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CollisionDetection")
        {
            /*cherryAnim.SetTrigger("collected");*/
            gameManagerScript.UpdateScore(1);
            Destroy(gameObject);
            /*StartCoroutine(DelayDestroyCherry());*/
        }
    }
    /*IEnumerator DelayDestroyCherry()
    {
        yield return new WaitForSeconds(cherryAnim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }*/
}
