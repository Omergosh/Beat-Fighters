    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HP : MonoBehaviour {
    public int startingHealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image player_spriteImage;
    public Sprite damagedSprite;
    public Sprite normalSprite;
    public Sprite deadSprite;
    public Sprite victorySprite;

    public bool isDead;
    private float hitStun = 0;
    bool hit;


    // Use this for initialization
    void Start ()
    {
        currentHealth = startingHealth;
        player_spriteImage.sprite = normalSprite;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            Debug.Log("HIT");
            TakeDamage();
        }
        if (hit)
        {
            this.hitStun += Time.deltaTime;

            if (this.hitStun >= 2f && !isDead)
            {
                this.hitStun = 0f;
                player_spriteImage.sprite = normalSprite;
                hit = false;
            }
        }

    }   

    public void TakeDamage ()
    {
        currentHealth -= 1;
        healthSlider.value = currentHealth;
        player_spriteImage.sprite = damagedSprite;
        hit = true;
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
        }
    }
}
