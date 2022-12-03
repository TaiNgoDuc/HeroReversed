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


    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
        
    }

    public void OnClickSetting() {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
