using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button restartBut;
    public Button exitBut;
    // Start is called before the first frame update
    void Start()
    {
        restartBut.onClick.AddListener(LoadScene);
        exitBut.onClick.AddListener(ExitToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    private void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
