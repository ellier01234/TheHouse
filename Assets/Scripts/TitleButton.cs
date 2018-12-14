using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {

    //called when title button is clicked
    public void GoToTitle()
    {
        //return to title scene
        SceneManager.LoadScene("Title");
    }
	
}
