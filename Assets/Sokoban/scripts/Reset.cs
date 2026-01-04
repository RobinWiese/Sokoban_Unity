using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour{

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _cratePrefab;
    

   
    void Update(){
        if(GameSceneMenu.isGamePaused == false){
            if(Input.GetKeyDown(KeyCode.R)){
                resetMidGame();
            }
        }
    }

    public void resetMidGame(){
        GameHUDScript.bewegungen = 0;
        GameHUDScript.kistenGeschoben = 0;

        GameObject b;
        for (int i = 0; i < GridManager.dictionaryCrates.Count; i++){
            b = GameObject.Find("Crate" + i);
            Destroy(b);
        }
        b = GameObject.Find("Player");
        Destroy(b);

        for (int i = 0; i < GridManager.resetCrates.Length; i++){
            var spawnedTile = Instantiate(_cratePrefab, GridManager.resetCrates[i], Quaternion.identity);
            spawnedTile.name = $"Crate{i}";

            GridManager.dictionaryCrates["Crate" + i] = spawnedTile.transform.position;
        }

        //die If-Abfrage existiert nur, damit die Variable spawnedTile auf der selben Ebene wie die anderen erzeugt wird, da es sonst zu einem Fehler kommt.
        if(1 == 1){
            var spawnedTile = Instantiate(_playerPrefab, GridManager.resetSpieler, Quaternion.identity);
            spawnedTile.name = $"Player";
        }

    }

    public void resetWin(){
        GameHUDScript.bewegungen = 0;
        GameHUDScript.kistenGeschoben = 0;
        PlayerController.winCondition = false;
        GridManager.dictionaryCrates = null;
        GameSceneMenu.isGamePaused = false;
    }
}
