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

    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        conductorScript = conductor.GetComponent<ConductorScript>();
        firePos = transform.Find("firePos2");
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown("j"))
        {
            Fire();
        }

        if (conductorScript.newBeatThisFrame)
        {
            if (gameManagerScript.attackBeatTrack[conductorScript.beatNumber] > 0)
            {
                Fire();
            }
        }
	}   

    void Fire()
    {
        Instantiate(bullet, firePos.position, Quaternion.identity);
    }
}
