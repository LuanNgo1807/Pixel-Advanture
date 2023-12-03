using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMove : MonoBehaviour
{
    public Rigidbody2D appleRid;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        Move();
        StartCoroutine(DelayDestroyApple());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        appleRid.AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);
    }
    IEnumerator DelayDestroyApple()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
