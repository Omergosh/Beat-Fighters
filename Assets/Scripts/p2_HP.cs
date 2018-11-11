using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2_HP : MonoBehaviour {
    public int startingHealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image P2_spriteImage;
    public Sprite damagedSprite;
    public Sprite normalSprite;
    public Sprite deadSprite;

    p2_Shoot p2_Shoot;
    bool isDead;
    private float hitStun = 0;


    // Use this for initialization
    void Start ()
    {
        p2_Shoot = GetComponent<p2_Shoot>();
        currentHealth = startingHealth;
        P2_spriteImage.sprite = normalSprite;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                P2_spriteImage.sprite = damagedSprite;
                TakeDamage();
        }

       this.hitStun += Time.deltaTime;

        if (this.hitStun >= 2f && !isDead)
        {
            this.hitStun = 0f;
            P2_spriteImage.sprite = normalSprite;
        }
    }   

    public void TakeDamage ()
    {
        currentHealth -= 1;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        p2_Shoot.enabled = false;
        P2_spriteImage.sprite = deadSprite;
        this.enabled = false;
    }
}
