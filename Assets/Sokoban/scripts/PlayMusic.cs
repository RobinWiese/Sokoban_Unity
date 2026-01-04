using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour{

    [SerializeField] private AudioSource musicFile;
    private GameObject[] other;
    private static PlayMusic instance = null;
    private bool isPlaying;

    
    void Awake(){
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }else{
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        musicFile.Play();
        isPlaying = true;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            if(isPlaying){
                StopMusicFile();
                isPlaying = false;
            }else{
                PlayMusicFile();
                isPlaying = true;
            }
        }
    }

    public void PlayMusicFile(){
        if(musicFile.isPlaying) return;
        musicFile.Play();
    }

    public void StopMusicFile(){
        musicFile.Stop();
    }

}