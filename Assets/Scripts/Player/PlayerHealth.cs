using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject player;

    public Animator playerAnim;
    public CapsuleCollider2D playerCol;

    public AudioSource playerHealtSource;
    public AudioClip hitSound;

    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealtSource.PlayOneShot(hitSound, 1.0f);
        if(currentHealth <= 0)
        {
            Destroy(player);
            menuCanvas.SetActive(true);
        }
    }
}
