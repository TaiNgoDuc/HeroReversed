using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseGamebtn;
    [SerializeField] GameObject resumeGamebtn;
    [SerializeField] GameObject exitGamebtn;
    
    void Start()
    {
        // resumeGamebtn.SetActive(false);
        // exitGamebtn.SetActive(false);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
        resumeGamebtn.SetActive(true);
        exitGamebtn.SetActive(true);
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
        resumeGamebtn.SetActive(false);
        exitGamebtn.SetActive(false);
    }

    public void ExitGame() {
        SceneManager.LoadScene("MenuScenes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
