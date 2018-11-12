using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManagerScript : MonoBehaviour
{

    public static CharacterSelectManagerScript instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public string selectedCharacter1 = "";
    public string selectedCharacter2 = "";

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    //Initializes the game for each level.
    void StartGame()
    {
        // Characters are selected - change Scene!
        Debug.Log(selectedCharacter1);
        Debug.Log(selectedCharacter2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    //Update is called every frame.
    void Update()
    {
        if (selectedCharacter1 != null && selectedCharacter2 != null)
        {
            if (Input.anyKeyDown)
            {
                StartGame();
            }
        }
    }

    public void selectCharacter(int player, string characterToSelect)
    {
        if (player == 1)
        {
            selectedCharacter1 = characterToSelect;
        }
        else
        {
            selectedCharacter2 = characterToSelect;
        }
    }
}
