using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance;
    public AudioClip audioStartbtn;
    public AudioClip audioSettingbtn;
    public AudioSource sourceAudio;
    public TypePlayer currentPlayer;
    public PlayerScript player;

    public void playSoundStartbtn() {
        sourceAudio.clip = audioStartbtn;
        sourceAudio.Play();
    }

    public void playSoundSettingbtn() {
        sourceAudio.clip = audioSettingbtn;
        sourceAudio.Play();
    }


    public void Awake() {
        if (!Instance) {
            Instance = this;
        }
    }


}
