using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GridManager : MonoBehaviour{


    private int _width, _heigth;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _cratePrefab;

    [SerializeField] private Transform _cam;
    [SerializeField] private Camera _orthographicCam;

    private char[] symbols = {' ', '$', '*', '-', '+', '@', '.', '#'};
    // {'empty tile', 'Crate', 'Crate on target', 'player on target', 'Player start', 'target', 'wall'}



    public static Vector3[] TargetPos;
    public static Dictionary<string, Vector3> dictionaryCrates;
    

    public static Vector3[] resetCrates;
    public static Vector3 resetSpieler;

    private int targets;
    private int crates;
    

    void Start(){
        _width = LevelLoader.Horizontal;
        _heigth = LevelLoader.Vertikal;

        getAmountOfCratesTargets();
        GenerateGrid();
    }

    void GenerateGrid(){
        TargetPos = new Vector3[targets];
        resetCrates = new Vector3[crates];
        dictionaryCrates = new Dictionary<string, Vector3>();


        //generiert erste Ebene bestehend aus den Tiles (normaler Untergrund) und den Targets (Abstellfläche für Kisten/Crates)

        //wenn man die Zeile "LevelLoader.zeilen[y-2]" laden würde, würde man das Spielfeld einmal auf den Kopf drehen. < ist hierbei die höhe des Levels / die Anzahl an zeilen im Textdokument, wovon wir 2 abziehen, da die Zeilen mit den Längen, Breiten Werten nicht mit verarbeitet werden.
        //Durch das einsetzen von "_heigth - 1 - y + 2" wirkt man dem ganzen entgegen, da die z.B. 5. Zeile im 5. Feld in zeilen ist. Demnach wird diese Zeile beim y wert 4 erreicht (zeilen[4]), und vom Gridmanager mit dem y Wert 4 gespawnt, was am oberen Ende des generierten Feldes liegt.
        int counter = 0;
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _heigth; y++){
                string aktuelleZeile = LevelLoader.zeilen[_heigth - 1 - y + 2];
                char aktullesZeichen = aktuelleZeile[x];
                if(aktullesZeichen == '.' || aktullesZeichen == '*' || aktullesZeichen == '+'){
                    var spawnedTile = Instantiate(_targetPrefab, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"Target";

                    Debug.Log(aktullesZeichen + " Gefundenes Target:");
                    TargetPos[counter] = spawnedTile.transform.position;
                    counter++;
                }else{
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"Tile";
                }
            }
        }


        //generiert zweite Ebene bestehend aus Wänden, Kisten und dem Spieler
        counter = 0;
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _heigth; y++){
                string aktuelleZeile = LevelLoader.zeilen[_heigth - 1 - y + 2];
                char aktullesZeichen = aktuelleZeile[x];
                if(aktullesZeichen == '#'){
                    var spawnedTile = Instantiate(_wallPrefab, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"Wall";
                }else if(aktullesZeichen == '$' |aktullesZeichen == '*'){
                    var spawnedTile = Instantiate(_cratePrefab, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"Crate{counter}";

                    dictionaryCrates.Add(spawnedTile.name, spawnedTile.transform.position);
                    resetCrates[counter] = spawnedTile.transform.position;
                    counter++;
                }else if(aktullesZeichen == '@' | aktullesZeichen == '+'){
                    var spawnedTile = Instantiate(_playerPrefab, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"Player";

                    resetSpieler = spawnedTile.transform.position;
                }
            } 
        }

        //ändert die Position der Kamera (x,y,z), da das erste Feld bei(x:0, y: 0) gneriert wird, was auch der Mittelpunkt der Kamera ist. z, -10 ist der Standardwert der Hauptkamera
        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_heigth/2 -0.5f, -10f);
        

        if(_heigth % 2 != 0){
            _orthographicCam.orthographicSize = _heigth / 2 + 1.5f;
        }else{
            _orthographicCam.orthographicSize = _heigth / 2 + 1f;
        }
    }


    //um die länge der CratePos und TargetPos Arrays zu bestimmen wird diese Methode genutzt, da ansonsten bei der Win condition leere Felder mit null als gleich gewertet werden und somit das gewinnen unmöglich machen
    public void getAmountOfCratesTargets(){
        crates = 0;
        targets = 0;
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _heigth; y++){
                string aktuelleZeile = LevelLoader.zeilen[_heigth - 1 - y + 2];
                char aktullesZeichen = aktuelleZeile[x];
                if(aktullesZeichen == '$' | aktullesZeichen == '*'){
                    crates++;
                }else if(aktullesZeichen == '.' || aktullesZeichen == '*' || aktullesZeichen == '+'){
                    targets++;
                }
            } 
        }

    }

}
