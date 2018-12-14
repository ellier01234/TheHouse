using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    // text components used to display the high scores 
    public List<Text> highScoreDisplays = new List<Text>();

    // internal data for score values 
    private List<int> highScoreData = new List<int>();

	// Use this for initialization
	void Start () {
        // load the high score data from the player prefs
        LoadHighScoreData();

        // get our current score from PlayerPrefs 
        int currentScore = PlayerPrefs.GetInt("score", 0);

        // check if we got a new high score
        bool haveNewHighScore = IsNewHighScore(currentScore); 
        if (haveNewHighScore == true)
        {
            // add new score to the data
            AddScoreToList(currentScore);

            //save updated data 
            SaveHighScoreData();

        }

        // update the visual display
        UpdateVisualDisplay(); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index get the name for our playerPrefs key 
            string prefsKey = "highScore" + i.ToString();

            // use this key to get the high score value from PlayerPrefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            // store this score value in our internal data list 
            highScoreData.Add(highScoreValue);
            

        }
    }

    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // find the specific text and numbers in our list 
            // set the text to the numerical score
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {
        // loop through the high scores and see if ours are higher than any of them 
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            if (scoreToCheck > highScoreData[i])
                {
                // our score is higher!
                // return to the calling code that we DO have a new high score 
                return true;
            }
        }
            // default: false 
            // we did not find any scores that our score was higher than...
            return false;
    }

    private void AddScoreToList(int newScore)
    {
        // loop through the high scores and find where the new score fits 
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // is our score higher than the score we're checking in the list?
            if (newScore > highScoreData[i])
            {
                // our score IS higher 
                // since we're going from highest to lowest, the first 
                // time our score is higher, this is where it must go 

                // insert the new score into the list here 
                highScoreData.Insert(i, newScore);

                // trim the last item off the list 
                highScoreData.RemoveAt(highScoreData.Count - 1);

                // We're done, we must exit early
                return;
            }

        }
    }

    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index get the name for our playerPrefs key 
            string prefsKey = "highScore" + i.ToString();

            // get the current high score entry from the data 
            int highScoreEntry = highScoreData[i];

            // save this data to the PlayerPrefs 
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
        }

        // save the player prefs to disk 
        PlayerPrefs.Save();
    }

}
