using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PlayerController playerScript;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(playerScript.isGrounded || playerScript.isOnBox || playerScript.isOnFireTrapOff)
        {
            playerScript.SetJump();
        }
        
        playerScript.mobileButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playerScript.mobileButton = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
