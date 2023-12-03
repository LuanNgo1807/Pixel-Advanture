using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollisionDetection : MonoBehaviour
{
    public GameObject breakEffect;
    private GameObject breakEffectDes;
    private BoxHp[] boxHpScriptsArray;
    private Animator[] boxHitAnim;

    // Start is called before the first frame update
    void Start()
    {
        boxHpScriptsArray = GameObject.FindGameObjectsWithTag("BreakableBox")
                                       .Select(obj => obj.GetComponent<BoxHp>())
                                       .ToArray();
        boxHitAnim = GameObject.FindGameObjectsWithTag("BreakableBox")
                                       .Select(obj => obj.GetComponent<Animator>())
                                       .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator hitAnim = collision.gameObject.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("BreakableBox"))
        {
            BoxHp boxHpScripts = collision.gameObject.GetComponent<BoxHp>();
            if(hitAnim != null)
            {
                hitAnim.SetBool("box3Hit", true);
                StartCoroutine(DelayBetweenAnim());
            }
            boxHpScripts.hitsCanTake--;
            if(boxHpScripts.hitsCanTake == 0)
            {
                Destroy(collision.gameObject);
                breakEffectDes = Instantiate(breakEffect, collision.transform.position, collision.transform.rotation);
                StartCoroutine(DelayDestroyBreakEffect());
            }
        }
        IEnumerator DelayBetweenAnim()
        {
            yield return new WaitForSeconds(0.5f);
            if(hitAnim != null)
            {
                hitAnim.SetBool("box3Hit", false);
            }
        }
    }
    IEnumerator DelayDestroyBreakEffect()
    {
        yield return new WaitForSeconds(0.3f) ;
        Destroy(breakEffectDes);
    }
    
}
