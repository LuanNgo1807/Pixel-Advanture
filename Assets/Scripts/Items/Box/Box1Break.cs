using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Break : MonoBehaviour
{
    public Vector2 directionBreak;
    public Rigidbody2D pieceRid;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        AddForceBreak();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddForceBreak()
    {
        pieceRid.AddForce(directionBreak * force, ForceMode2D.Impulse);
    }
}
 