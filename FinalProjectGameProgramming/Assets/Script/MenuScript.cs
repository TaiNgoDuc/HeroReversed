using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] Button startButton;
    [SerializeField] Button settingButton;
    [SerializeField] Slider musicControl;
    public static GameManager Instance;


    // Start is called before the first frame update
    

    public void changeVolume() {
        AudioListener.volume = musicControl.value;
        saveVolume();
    }

    public void saveVolume(){
        PlayerPrefs.SetFloat("changed", musicControl.value);
    }

    public void loadChangedVolume() {
        musicControl.value = PlayerPrefs.GetFloat("changed");
    }

    void Awake()
    {
        startButton.onClick.AddListener(OnClickStart);
        settingButton.onClick.AddListener(OnClickSetting);
        // quit.onClick.AddListener(OnClickQuit);
        
    }

    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);

        // if(!PlayerPrefs.HasKey("changed")) {
        //     PlayerPrefs.SetFloat("changed", 1);
        // } else {
        //     loadChangedVolume();
        // }
        
    }

    public void OnClickStart() {
        // GameManager.Instance.playSoundStartbtn();
    }

    public void OnClickSetting() {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
        GameManager.Instance.playSoundSettingbtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
