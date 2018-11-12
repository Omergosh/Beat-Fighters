using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButtonScript : MonoBehaviour
{

    public CharacterSelectManagerScript characterSelectManagerScript;
    public int player;
    public string characterToSelect = "Squriby";

    void Start()
    {
        characterSelectManagerScript = FindObjectOfType<CharacterSelectManagerScript>();
    }

    public void selectCharacter()
    {
        if (player == 1)
        {
            characterSelectManagerScript.selectedCharacter1 = characterToSelect;
        }
        else
        {
            characterSelectManagerScript.selectedCharacter2 = characterToSelect;
        }
    }
}