using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    // References to GameObjects in scene
    public GameObject camera;
    public GameObject player1;
    public GameObject player2;
    public ConductorScript conductorScript;
    public Text phasesText;

    int Phase; //4 phases
    bool Turn; //Player 1 is true, Player 2 is false
    string Player;

    // Beat track used to keep track of attacking notes and defending notes
    public int[] attackBeatTrack = new int[4];
    public int[] defenseBeatTrack = new int[4];

    // Use this for initialization
    void Start () {
        Phase = -1;
        Turn = true;
        togglePlayer(player1, false);
        togglePlayer(player2, false);
	}
	
	// Update is called once per frame
	void Update () {
        if (conductorScript.newBarThisFrame)
        { 
            Phase += 1;
            if (Phase == 1)
            {
                //Listening phase for attacker
                togglePlayer(player1, false);
                togglePlayer(player2, false);
                phasesText.text = "Hey! Listen! Get ready to attack!";
            }
            if (Phase == 2)
            {
                //Attack phase
                togglePlayer(player1, Turn);
                togglePlayer(player2, !Turn);
                if (Turn)
                {
                    phasesText.text = "Player 1 attack!";
                }
                else
                {
                    phasesText.text = "Player 2 attack!";
                }

            }
            if (Phase == 3)
            {
                //Listening phase for defender
                togglePlayer(player1, false);
                togglePlayer(player2, false);
                phasesText.text = "Hey! Listen! Get ready to defend!";
            }
            if (Phase == 4)
            {
                //Defence phase
                togglePlayer(player1, !Turn);
                togglePlayer(player2, Turn);
                if  (Turn)
                {
                    phasesText.text = "Player 2 defend!";
                }
                else
                {
                    phasesText.text = "Player 1 defend!";
                }
                Turn = !Turn;
                Phase = 0;
            }
        }
	}

    void togglePlayer(GameObject player, bool toggle)
    {
        foreach (MonoBehaviour script in player.GetComponents<MonoBehaviour>())
        {
            script.enabled = toggle;
        }
    }
}
