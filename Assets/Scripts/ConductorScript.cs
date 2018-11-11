using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorScript : MonoBehaviour {

    //Conductor
    int crotchetsperbar = 8;
    public float bpm = 60; //= 180; // gives the bpm of the current track
    public float crotchet; // time duration of a beat
    public float songposition;
    int beatsperbar;

    public float lasthit; // = 0.0f;
    public float actuallasthit;
    float nextbeattime = 0.0f;
    float nextbartime = 0.0f;

    public float offset = 0f; //0.2f; // offset at beginning of music file; positive means the song must be minussed!
    //public float addoffset; // additional, per level offset
    //public static float offsetstatic = 0.40f;
    //public static bool hasoffsetadjusted = false;

    // Useful indicators for where we are in the song
    public int beatnumber = 0;
    public int barnumber = 0; // Not applicable yet
    public bool newBeatThisFrame = false; // Has the track progressed to a new beat this frame?
    public bool newBarThisFrame = false; // Has the track progressed to a new bar this frame? AKA in this case did the track just loop 

    // Other objects/variables
    AudioSource audio;

    // Use this for initialization
    void Start () {
        crotchet = 60f / bpm;
        beatsperbar = 4;

        audio = GetComponent<AudioSource>();

        // Start the song
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        // Keep track of position in song
        songposition = (float)(audio.time) * audio.pitch - offset;
        newBeatThisFrame = false;
        newBarThisFrame = false;
        //Debug.Log(audio.time);

        // If new beat has been reached this frame
        if(beatnumber != (int)(songposition / crotchet))
        {
            // Change beat to new value first
            beatnumber = (int)(songposition / crotchet);
            newBeatThisFrame = true; // VERY IMPORTANT for other GameObjects to use for triggers

            //If applicable, change current barnumber too
            if (beatnumber == 0)
            {
                barnumber++;
                newBarThisFrame = true;
            }

            // Do something you want to happen each beat!
            // In this case, we'll go with a Debug.Log() which is basically a print() or printf() statement
            Debug.Log(beatnumber);
            //Debug.Log("UNS");
        }

        if (Input.anyKeyDown)
        {

        }
        
    }
}
