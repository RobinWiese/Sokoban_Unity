using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDScript : MonoBehaviour{
    [SerializeField] private Text hudMoves;
    [SerializeField] private Text hudPushes;

    public static int bewegungen {get; set;}
    public static int kistenGeschoben {get; set;}


    void Start(){
        float height = Screen.height;

        RectTransform rt = (RectTransform)hudMoves.transform;
        float widthText = rt.rect.width;
        hudMoves.transform.position = new Vector3(widthText / 2 + 25, height - 25, 0);

        rt = (RectTransform)hudPushes.transform;
        widthText = rt.rect.width;
        hudPushes.transform.position = new Vector3(widthText  / 2 + 25, height - 50, 0);

        hudMoves.text = "Bewegungen: " + bewegungen;
        hudPushes.text = "Verschiebungen: " + kistenGeschoben;

        bewegungen = 0;
        kistenGeschoben = 0;
    }
    
    void Update(){
        hudMoves.text = "Bewegungen: " + bewegungen;
        hudPushes.text = "Verschiebungen: " + kistenGeschoben;
    }
    
}
