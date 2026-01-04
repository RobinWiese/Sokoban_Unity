using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Vector2 direction;
    private RaycastHit crate;

    public static bool winCondition;

    

    void Update(){
        
        if(GameSceneMenu.isGamePaused == false){

            direction = Vector2.zero;
        
            if(Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow) ){
                if(CanMove(KeyCode.W) == true){
                    move(direction);
                }
            }else if(Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow)){
                if(CanMove(KeyCode.A) == true){
                    move(direction);
                }
            }else if(Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow)){
                if(CanMove(KeyCode.S) == true){
                    move(direction);
                }
            }else if(Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow)){
                if(CanMove(KeyCode.D) == true){
                    move(direction);
                }
            }
        }

    }

    public bool CanMove(KeyCode b){
        direction = Vector2.zero;
        
        if(b == KeyCode.W){
            direction = Vector2.up;
        }else if(b == KeyCode.A){
            direction = Vector2.left;
        }else if(b == KeyCode.S){
            direction = Vector2.down;
        }else if(b == KeyCode.D){
            direction = Vector2.right;
        }

        if(Physics.Raycast(transform.position, direction, out var hit, 1f)){
            if(hit.collider.name == "Wall"){
                return false;
            }else{
                crate = hit;
                moveCrate();
                return false;
            }
        }else{
            GameHUDScript.bewegungen++;
            return true;
        }

    }

    public void checkTarget(){
        int counter = 0;
        
        for(int i = 0; i < GridManager.TargetPos.Length; i++){
            for (int j = 0; j < GridManager.dictionaryCrates.Count; j++){
                if(Vector3.Distance(GridManager.TargetPos[i], GridManager.dictionaryCrates["Crate" + j] ) == 0f){
                    counter++;
                }
            }
        }
        
        if(counter == GridManager.TargetPos.Length){
            winCondition = true;
        }
    }

    public void moveCrate(){
        if(Physics.Raycast(crate.transform.position, direction, out var hit, 1f)){
        }else{
            crate.transform.position = crate.transform.position + new Vector3(direction.x, direction.y, 0f);
            move(direction);

            for (int i = 0; i < GridManager.dictionaryCrates.Count; i++){
                if(crate.transform.name == "Crate" + i){
                    GridManager.dictionaryCrates["Crate" + i] = crate.transform.position;
                }
            }
            GameHUDScript.kistenGeschoben++;
            checkTarget();
        }
    }
    //der move befehl wurde in die crate klasse bewegt, da sonst egal ob der crate sich bewegt oder nicht der spieler hinterher rennt und somit theoretisch auf dem gleichen feld wie der crate stehen kann.

    public void move(Vector2 direction){
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0f);
    }
    
}





