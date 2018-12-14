using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    // Variable to track the visible text lives
    //      Public to let us drag and drop in the editor
    public Text livesText;

    // Variable to track the numerical lives
    //      Private because other scripts should not 
    //          change it directly
    //      Default to 0 since we should not have any 
    //          score when starting
    private int numericalLives = 3;

    // Use this for initialization
    void Start () {
        // Get the lives from the prefs database
        // Use a default of 0 of no lives was saved
        // Store the result in our numerical lives variable
        numericalLives = PlayerPrefs.GetInt("lives", 3);

        // Update the visual lives
        livesText.text = numericalLives.ToString();

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void LoseLife()
    {
        numericalLives = numericalLives - 1;
        livesText.text = numericalLives.ToString(); 

    }

    public void SaveLives()
    {
        PlayerPrefs.SetInt("lives", numericalLives);
    }

    public bool IsGameOver()
    {
        if (numericalLives <= 0)
        {
            return true;

        }

        else
        {
            return false;
        }

    }
}
