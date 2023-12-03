using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHp : MonoBehaviour
{
    public int hitsCanTake;
    public Animator boxHitAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CollisionDetection")
        {
            boxHitAnim.SetBool("box3Hit", true);
            Debug.Log("ok");
        }
        else
        {
            boxHitAnim.SetBool("box3Hit", false);
        }
    }*/
}
