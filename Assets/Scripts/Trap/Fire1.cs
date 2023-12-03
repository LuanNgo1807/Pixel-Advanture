using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Fire1 : MonoBehaviour
{
    public Animator fireAnim;
    public bool turnOn;
    private GameObject[] flameArray;
    // Start is called before the first frame update
    void Start()
    {
        flameArray = GameObject.FindGameObjectsWithTag("Flame").Select(obj => obj.gameObject).ToArray();
        TurnOnFire();
    }

    // Update is called once per frame
    void Update()
    {
        /*StartCoroutine("TurnOnAgain");*/
    }
    private void TurnOnFire()
    {
        StartCoroutine(TurnOnAndOff());
    }

    /*IEnumerator TurnOnAndOff()
    {
        fireAnim.SetBool("turnOnFire", true);

        foreach (var flame in flameArray)
        {
            flame.SetActive(true);
        }

        yield return new WaitForSeconds(2.0f);

        fireAnim.SetBool("turnOnFire", false);

        foreach (var flame in flameArray)
        {
            flame.SetActive(false);
        }

        yield return new WaitForSeconds(3.0f);

        // Repeat the process
        StartCoroutine(TurnOnAndOff());
    }*/
    IEnumerator TurnOnAndOff()
    {
        fireAnim.SetBool("turnOnFire", true);
        foreach (var flame in flameArray)
        {
            flame.SetActive(true);
        }
        turnOn = true;

        yield return new WaitForSeconds(2.0f);
        fireAnim.SetBool("turnOnFire", false);
        foreach (var flame in flameArray)
        {
            flame.SetActive(false);
        }
        turnOn = false;

        yield return new WaitForSeconds(2.0f);
        StartCoroutine(TurnOnAndOff());
    }
}
