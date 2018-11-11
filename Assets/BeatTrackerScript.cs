using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTrackerScript : MonoBehaviour {
    public GameObject gameManager;
    public GameObject conductor;
    public GameManagerScript gameManagerScript;
    public ConductorScript conductorScript;

    // Use this for initialization
    void Start () {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        conductorScript = conductor.GetComponent<ConductorScript>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(conductorScript.nextBeatTime);
        //Debug.Log(conductorScript.songPosition % conductorScript.crotchet);
        transform.Rotate(Vector3.forward, (conductorScript.songPosition % conductorScript.crotchet)/* - transform.rotation.z)*/ * -360 * Time.deltaTime);
	}
}
