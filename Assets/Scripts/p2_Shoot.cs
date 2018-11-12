using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2_Shoot : MonoBehaviour {
    public GameObject gameManager;
    public GameObject conductor;
    public GameManagerScript gameManagerScript;
    public ConductorScript conductorScript;
    public GameObject bullet;
    private Transform firePos;
    bool cooldown;
    int[] hitMiss;

    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        conductorScript = conductor.GetComponent<ConductorScript>();
        firePos = transform.Find("firePos2");
    }

    // Update is called once per frame
    void Update()
    {
        if (conductorScript.newBeatThisFrame)
        {
            cooldown = false;
        }

        if (Input.GetKeyDown("j") && !cooldown)
        {
            Fire();
            hitMiss = conductorScript.BeatCheck();
            if (hitMiss[0] == 1)
            {
                if (gameManagerScript.Turn)
                {
                    gameManagerScript.defenseBeatTrack[hitMiss[1]] = 1;
                }
                else
                {
                    gameManagerScript.attackBeatTrack[hitMiss[1]] = 1;
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
