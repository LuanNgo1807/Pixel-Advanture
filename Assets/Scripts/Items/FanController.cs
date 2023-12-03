using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public Animator fanAnim;
    public bool fanOn = false;
    public bool getState;
    public BoxCollider2D fanBoxCol;
    // Start is called before the first frame update
    void Start()
    {
        TurnOn();
    }

    // Update is called once per frame
    void Update()
    {
        getState = fanOn;
    }
    private void TurnOn()
    {
        fanAnim.SetBool("on", true);
        fanOn = true;
        fanBoxCol.enabled = true;
        StartCoroutine(DelayFan());
    }
    IEnumerator DelayFan()
    {
        yield return new WaitForSeconds(2);
        fanAnim.SetBool("on", false);
        fanOn = false;
        fanBoxCol.enabled = false;

        yield return new WaitForSeconds(2);
        TurnOn();
    }
}
