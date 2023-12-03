using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class ButtonMoveLeft : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public PlayerController playerScript;
    public void OnPointerEnter(PointerEventData eventData)
    {
        playerScript.mobileButton = true;
        playerScript.horizontal = -1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playerScript.horizontal = 0;
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
