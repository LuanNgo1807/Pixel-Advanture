using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startBut;
    public Button exitBut;
    // Start is called before the first frame update
    void Start()
    {
        startBut.onClick.AddListener(StartScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartScene()
    {
        SceneManager.LoadScene("Level1");
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
