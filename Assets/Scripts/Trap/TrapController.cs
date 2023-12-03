using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public bool flipDirection = true;
    public bool rightFace = true;
    public float sawSpeed;
    public float directionX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndFlipDirection();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spike"))
        {
            flipDirection = !flipDirection;
            FlipScale();
        }
    }

    // flip face of the saw when trigger with the ground
    private void FlipScale()
    {
        if((directionX < 0 && rightFace) || (directionX > 0 && !rightFace))
        {
            rightFace = !rightFace;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    private void MoveAndFlipDirection()
    {
        directionX = flipDirection ? -1 : 1;
        transform.Translate(new Vector2(directionX * sawSpeed * Time.deltaTime, 0));
    }
}
