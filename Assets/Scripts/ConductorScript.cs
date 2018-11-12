using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorScript : MonoBehaviour {

    //Conductor
    int crotchetsPerBar = 4;
    public float bpm = 60; //= 180; // gives the bpm of the current track
    public float crotchet; // time duration of a beat
    public float songPosition;
    int beatsPerBar;

    public float lastHit; // = 0.0f;
    public float actualLastHit;
    public float nextBeatTime = 0.0f;
    public float nextBarTime = 0.0f;
    public float previousBeatTime = 0.0f;
    public float previousBarTime = 0.0f;

    public float offset; //0.2f; // offset at beginning of music file; positive means the song must be minussed!
    //public float addOffset; // additional, per level offset
    //public static float offsetStatic = 0.40f;
    //public static bool hasOffsetAdjusted = false;

    // Useful indicators for where we are in the song
    public int beatNumber = 0;
    public int barNumber = 0; // Not applicable yet
    public bool newBeatThisFrame = false; // Has the track progressed to a new beat this frame?
    public bool newBarThisFrame = false; // Has the track progressed to a new bar this frame? AKA in this case did the track just loop 

    // Variables used for correcting/tracking the timing beat inputs
    float beatLeeway = 0.15f;

    // Other objects/variables
    AudioSource audio;

    // Use this for initialization
    void Start () {
        crotchet = 60f / bpm; // = (number of seconds in a minute)/(beats per minute)
        beatsPerBar = 4;

        audio = GetComponent<AudioSource>();

        // Start the song
        audio.Play();
    }

    // Update is called once per frame
    void Update() {
        // Keep track of position in song
        songPosition = ((audio.time * audio.pitch) - offset) % (crotchet * crotchetsPerBar);
        if (songPosition < 0)
        {
            songPosition += (crotchet * crotchetsPerBar);
        }
        newBeatThisFrame = false;
        newBarThisFrame = false;
        //Debug.Log(audio.time);

        previousBeatTime = (songPosition % crotchet);
        nextBeatTime = crotchet - previousBeatTime;

        // If new beat has been reached this frame
        if (beatNumber != (int)(songPosition / crotchet))
        {
            // Change beat to new value first
            beatNumber = (int)(songPosition / crotchet);
            newBeatThisFrame = true; // VERY IMPORTANT for other GameObjects to use for triggers

            //If applicable, change current barnumber too
            if (beatNumber == 0)
            {
                barNumber++;
                newBarThisFrame = true;
            }

            // Do something you want to happen each beat!
            // In this case, we'll go with a Debug.Log() which is basically a print() or printf() statement
            //Debug.Log(beatNumber);
            //Debug.Log("UNS");
        }

        //Debug.Log(previousBeatTime);

        if (Input.anyKeyDown)
        {
            int[] beatCheck = BeatCheck();
            if (beatCheck[0] == 1)
            {
                // Test code goes here
                //Debug.Log("UNS" + beatCheck[1].ToString());
            }
        }
    }
        
    public int[] BeatCheck()
    {
        //
        // Return value is an array of two integers:
        // [if a button press on this frame is valid for a beat (0 = false; 1 = true),
        //  which beat the button press would correspond to if valid (0-3)]
        int[] checkReturn = new int[2];

        if(previousBeatTime <= beatLeeway || nextBeatTime <= beatLeeway)
        {
            checkReturn[0] = 1;

            if (nextBeatTime <= previousBeatTime)
            {
                checkReturn[1] = (beatNumber + 1) % beatsPerBar;
            }
            else
            {
                checkReturn[1] = beatNumber % beatsPerBar;
            }
        }

        return checkReturn;
    }


}
