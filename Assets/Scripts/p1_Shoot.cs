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

    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        conductorScript = conductor.GetComponent<ConductorScript>();
        firePos = transform.Find("firePos1");
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown("a")) // || conductorScript.newBeatThisFrame
        {
            Fire();
        }

        if (Input.GetKeyDown("a"))
        {
            gameManagerScript.attackBeatTrack[conductorScript.beatNumber] = 1;
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
