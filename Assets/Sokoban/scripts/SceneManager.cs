using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour{


    public static void GoToLevelMenue(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("LevelMenu");
	}

    public static void GoToHauptMenue(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

    public static void GoToGameScene(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public static void Quit(){
		Application.Quit();
	}
    	
}
