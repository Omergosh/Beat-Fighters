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
        transform.Rotate(Vector3.forward, conductorScript.offset * 360);
        transform.Rotate(Vector3.forward, -90);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(conductorScript.nextBeatTime);
        //Debug.Log(conductorScript.songPosition % conductorScript.crotchet);
        float rotationSpeed = (Time.deltaTime / (conductorScript.crotchet)) * -360;
        Debug.Log(Input.GetAxis("Vertical"));
        //if(Input.GetAxis("Vertical") == 180 || Input.GetAxis("Vertical") == 0)
       // {
           // rotationSpeed = -rotationSpeed;
       // }
        transform.Rotate(Vector3.forward, rotationSpeed);
	}
}
