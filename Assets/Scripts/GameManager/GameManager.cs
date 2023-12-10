using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public AudioSource gameManagerAudio;
    public AudioClip gameSound;
    public AudioClip gameStart;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    private PlayerHealth playerHealthScript;
    public AudioSource sound;
    public AudioClip takeCherrySound;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerAudio.PlayOneShot(gameStart,1.0f);

        gameManagerAudio.clip = gameSound;
        gameManagerAudio.Play();
        gameManagerAudio.loop = true;
        gameManagerAudio.volume = 0.5f;

        score = 0;
        scoreText.text = "Score: " + score;

        playerHealthScript = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();
    }            

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    public void UpdateScore(int scoreToAdd)
    {
        sound.PlayOneShot(takeCherrySound, 1f);
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void UpdateHealth()
    {
        healthText.text = "Health: " + playerHealthScript.currentHealth;
    }
}
