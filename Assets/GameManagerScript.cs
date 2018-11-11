using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    // References to GameObjects in scene
    public GameObject camera;
    public GameObject conductor;
    public GameObject player1;
    public GameObject player2;

    // Beat track used to keep track of attacking notes and defending notes
    public int[] attackBeatTrack = new int[4];
    public int[] defenseBeatTrack = new int[4];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
