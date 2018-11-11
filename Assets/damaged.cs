using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damaged : MonoBehaviour {

    public Image P2_spriteImage;
    public Sprite damagedSprite;
    public Sprite normalSprite;
    public Slider p2_Slider;
    private bool isDamaged;
    private float hitStun;
    p2_HP p2_HP;


	// Use this for initialization
	void Start () {
        p2_HP = GetComponent<p2_HP>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            isDamaged = true;
            P2_spriteImage.sprite = damagedSprite;
            p2_HP.TakeDamage();
        }

        if (this.isDamaged)
        {
            this.hitStun += Time.deltaTime;

            if (this.hitStun >= 1f)
            {
                this.isDamaged = false;
                this.hitStun = 0f;
                P2_spriteImage.sprite = normalSprite;
            }
        }
	}
}
