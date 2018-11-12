using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_Shoot : MonoBehaviour {
    public GameObject gameManager;
    public GameObject conductor;
    public GameManagerScript gameManagerScript;
    public ConductorScript conductorScript;
    public GameObject bullet;
    private Transform firePos;
    public AudioSource sound;
    bool cooldown;
    int[] hitMiss;
    public AudioClip[] fireSound;


    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        conductorScript = conductor.GetComponent<ConductorScript>();
        firePos = transform.Find("firePos1");
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (conductorScript.newBeatThisFrame)
        {
            cooldown = false;      
        }

        if (Input.GetKeyDown("a") && !cooldown)
        {
            hitMiss = conductorScript.BeatCheck();
            if (hitMiss[0] == 1)
            {
                Fire();
                sound.clip = fireSound[hitMiss[1]];
                sound.Play();

                if (gameManagerScript.Turn)
                {
                    gameManagerScript.attackBeatTrack[hitMiss[1]] = 1;
                }
                else
                {
                    gameManagerScript.defenseBeatTrack[hitMiss[1]] = 1;
                }
            }
            cooldown = true;
        }
        

        if (Input.GetKeyDown("s"))
        {
            gameManagerScript.attackBeatTrack[conductorScript.beatNumber] = 0;
        }
    }   

    void Fire()
    {
        Instantiate(bullet, firePos.position, Quaternion.identity);
    }
}