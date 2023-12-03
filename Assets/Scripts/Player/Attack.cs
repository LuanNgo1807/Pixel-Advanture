using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //public GameObject apple;
    private PlayerController playerControllerScripts;
    // Start is called before the first frame update
    void Start()
    {
        /*playerControllerScripts = GameObject.Find("Player").gameObject.*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowApple();
        }
    }
    private void ThrowApple()
    {
        float offset = 0.25f;
        Vector2 spawnPos = new Vector2(transform.position.x + offset, transform.position.y - offset);
        //Instantiate(apple, spawnPos, apple.transform.rotation); 
    }
}
