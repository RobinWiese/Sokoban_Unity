using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.EventSystems;

public class LevelLoader : MonoBehaviour{

    private bool webGL = true;


    public static int Horizontal {get; set;}
    public static int Vertikal {get; set;}
    public static string[] zeilen {get; set;}

    
    public void levelButtonClicked(){

        //string name =  EventSystem.current.currentSelectedGameObject.name;
        //erstelleLevel(Int32.Parse("" + name[6]) * 10 + Int32.Parse("" + name[7]));

        string name =  EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        erstelleLevel(Int32.Parse("" + name[6]) * 10 + Int32.Parse("" + name[7]));
        
    }

    public void erstelleLevel(int ausgewaehltesLevel){

        Debug.Log("erstelleLevel");
        
        WebGLLevel.initLevels();

        string text = WebGLLevel.levelArray[ausgewaehltesLevel - 1];
        Debug.Log(text);
        zeilen = text.Split(new [] { ',' });
        Debug.Log(zeilen[0]);
        Debug.Log(zeilen[1]);
        
        
        //zeilen = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "level" + ausgewaehltesLevel + ".txt"));


        getReihenSpalten();
        SceneManager.GoToGameScene();
    }

    public void getReihenSpalten(){
        Horizontal =  Int32.Parse(zeilen[0]);
        Vertikal = Int32.Parse(zeilen[1]);
    }
    
}