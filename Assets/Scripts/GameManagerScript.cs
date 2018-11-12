using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameManagerScript : MonoBehaviour
{

    // References to GameObjects in scene
    public GameObject camera;
    public GameObject player1;
    public GameObject player2;
    public ConductorScript conductorScript;
    public Text phasesText;
    public Text beatText;
    public player_HP p1_HP;
    public player_HP p2_HP;


    public int Phase; //4 phases
    public bool Turn; //Player 1 is true, Player 2 is false

    // Beat track used to keep track of attacking notes and defending notes
    public int[] attackBeatTrack = new int[4] { 0, 0, 0, 0 };
    public int[] defenseBeatTrack = new int[4] { 0, 0, 0, 0 };


    // Use this for initialization
    void Start()
    {
        Phase = -1;
        Turn = true;
        togglePlayer(player1, false);
        togglePlayer(player2, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (conductorScript.newBeatThisFrame)
        {
            beatText.text = (conductorScript.beatNumber + 1).ToString();
        }
        if (conductorScript.newBarThisFrame)
        {
            Phase += 1;
            togglePlayer(player1, false);
            togglePlayer(player2, false);
            if (Phase == 0)
            {
                //Listening phase for attacker
                phasesText.text = "Hey! Listen! Get ready to attack!";
            }
            if (Phase == 1)
            {
                //Attack phase
                togglePlayer(player1, Turn);
                togglePlayer(player2, !Turn);
                if (Turn)
                {
                    phasesText.text = "Player 1 attack!";
                    //beatText.Tranform.Translate = new Vector3(-130f, 0f, 0f);
                }
                else
                {
                    phasesText.text = "Player 2 attack!";
                    //beatText.Transform.Translate = new Vector3(130f, 0f, 0f);
                }

            }
            if (Phase == 2)
            {
                //Listening phase for defender
                phasesText.text = "Hey! Listen! Get ready to defend!";

                /*
                if (Turn)
                {
                    beatText.Transform.Translate = new Vector3(130f, 0f, 0f);
                }
                else
                {
                    beatText.Transform.Translate = new Vector3(-130f, 0f, 0f);
                } 
                */
            }
            if (Phase == 3)
            {
                //Defence phase
                togglePlayer(player1, !Turn);
                togglePlayer(player2, Turn);
                if (Turn)
                {
                    phasesText.text = "Player 2 defend!";
                    //beatText.Transform.Translate = new Vector3(130f, 0f, 0f);
                }
                else
                {
                    phasesText.text = "Player 1 defend!";
                    //beatText.Transform.Translate = new Vector3(-130f, 0f, 0f);
                }
            }
            if (Phase == 4)
            {
                //Results phase
                phasesText.text = "Results";

                /*
                if (Turn)
                {
                    beatText.Transform.Translate = new Vector3(-130f, 0f, 0f);
                }
                else
                {
                    beatText.Transform.Translate = new Vector3(130f, 0f, 0f);
                }
                */

                Debug.Log(attackBeatTrack[0].ToString() + " ATT 0");
                Debug.Log(attackBeatTrack[1].ToString() + " ATT 1");
                Debug.Log(attackBeatTrack[2].ToString() + " ATT 2");
                Debug.Log(attackBeatTrack[3].ToString() + " ATT 3");

                Debug.Log(defenseBeatTrack[0].ToString() + " DEF 0");
                Debug.Log(defenseBeatTrack[1].ToString() + " DEF 1");
                Debug.Log(defenseBeatTrack[2].ToString() + " DEF 2");
                Debug.Log(defenseBeatTrack[3].ToString() + " DEF 3");

                Debug.Log(defenseBeatTrack.SequenceEqual(attackBeatTrack));
                if (Turn)
                {
                    if (!(attackBeatTrack.SequenceEqual(defenseBeatTrack)))
                    {
                        p2_HP.TakeDamage();
                    }
                }
                else
                {
                    if (!(attackBeatTrack.SequenceEqual(defenseBeatTrack)))
                    {
                        p1_HP.TakeDamage();
                    }
                }
                if (p1_HP.isDead)
                {
                    togglePlayer(player1, false);
                    togglePlayer(player2, false);
                    p1_HP.player_spriteImage.sprite = p1_HP.deadSprite;
                    p2_HP.player_spriteImage.sprite = p2_HP.victorySprite;
                    phasesText.text = "Player 2 Victory!";
                    beatText.text = "";
                    Phase = 5;
                }
                else if (p2_HP.isDead)
                {
                    togglePlayer(player1, false);
                    togglePlayer(player2, false);
                    p1_HP.player_spriteImage.sprite = p1_HP.victorySprite;
                    p2_HP.player_spriteImage.sprite = p2_HP.deadSprite;
                    phasesText.text = "Player 1 Victory!";
                    beatText.text = "";
                    Phase = 5;
                }
                else
                {
                    Turn = !Turn;
                    Phase = 0;
                    attackBeatTrack = new int[4] { 0, 0, 0, 0 };
                    defenseBeatTrack = new int[4] { 0, 0, 0, 0 };
                }
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
