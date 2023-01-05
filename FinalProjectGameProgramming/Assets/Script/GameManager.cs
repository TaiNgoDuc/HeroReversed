using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance;
    public AudioClip audioStartbtn;
    public AudioClip audioSettingbtn;
    public AudioClip audioStartAgainbtn;
    public AudioClip audioMainMenubtn;
    public AudioClip audioControllKeybtn;
    public AudioClip audioShootSound;
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

    public void playSoundStartAgainbtn() {
        sourceAudio.clip = audioStartAgainbtn;
        sourceAudio.Play();
    }

    public void playSoundShoot() {
        sourceAudio.clip = audioShootSound;
        sourceAudio.Play();
    }

    public void playSoundMainMenu() {
        sourceAudio.clip = audioMainMenubtn;
        sourceAudio.Play();
    }

    public void playSoundControllKey() {
        sourceAudio.clip = audioControllKeybtn;
        sourceAudio.Play();
    }

    public void Awake() {
        if (!Instance) {
            Instance = this;
        }
    }


}
