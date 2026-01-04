using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneMenu : MonoBehaviour{

    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private GameObject vicotryScreen;
    [SerializeField] private GameObject hudCanvas;

    [SerializeField] private Text tMoves;
    [SerializeField] private Text tPushes;

    public static bool isGamePaused;
    private bool hudAn;


    void Start(){
        escapeMenu.SetActive(false);
        vicotryScreen.SetActive(false);
        hudAn = true;
        isGamePaused = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) ){
            if(isGamePaused){
                continueGame();
            }else{
                stopGame();
            }
        }

        //Hotkey H um HUD zu (de) -aktivieren
        if(Input.GetKeyDown(KeyCode.H)){
            if(hudAn){
                hudCanvas.SetActive(false);
                hudAn = false;
            }else{
                hudCanvas.SetActive(true);
                hudAn = true;
            }
        }

        if(PlayerController.winCondition){
            winScreen();
        }
    }

    void stopGame(){
        isGamePaused = true;
        hudCanvas.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void continueGame(){
        escapeMenu.SetActive(false);
        hudCanvas.SetActive(true);
        isGamePaused = false;
    }

    public void winScreen(){
        tMoves.text = "Bewegungen: " + GameHUDScript.bewegungen;
        tPushes.text = "Verschiebungen: " + GameHUDScript.kistenGeschoben;
        escapeMenu.SetActive(false);
        hudCanvas.SetActive(false);
        vicotryScreen.SetActive(true);
        isGamePaused = true;
    }
    
}

