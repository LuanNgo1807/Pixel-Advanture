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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * slimeDirection * Time.deltaTime);
        CheckLimit();
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
}

