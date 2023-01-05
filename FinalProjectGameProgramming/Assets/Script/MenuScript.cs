using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject selectPlayerPanel;
    [SerializeField] GameObject controllKeyPanel;
    [SerializeField] Button startButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button backButton;
    [SerializeField] Button controllKeyButton;
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
        backButton.onClick.AddListener(OnClickBack);
        controllKeyButton.onClick.AddListener(onClickControllKey);
    }

    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        selectPlayerPanel.SetActive(false);
        controllKeyPanel.SetActive(false);


        if(!PlayerPrefs.HasKey("changed")) {
            PlayerPrefs.SetFloat("changed", 1);
        } else {
            loadChangedVolume();
        }
        
    }

    public void OnClickStart() {
        mainMenuPanel.SetActive(false);
        selectPlayerPanel.SetActive(true);
        GameManager.Instance.playSoundStartbtn();
    }

    public void OnClickSetting() {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
        GameManager.Instance.playSoundSettingbtn();
    }

    public void OnClickBack() {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        selectPlayerPanel.SetActive(false);
        controllKeyPanel.SetActive(false);
    }

    public void onClickControllKey() {
        mainMenuPanel.SetActive(false);
        controllKeyPanel.SetActive(true);
        GameManager.Instance.playSoundSettingbtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
