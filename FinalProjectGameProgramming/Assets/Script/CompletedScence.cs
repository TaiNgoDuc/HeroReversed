using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletedScence : MonoBehaviour
{

    [SerializeField] Button mainMenuButton;

    void Awake()
    {
        mainMenuButton.onClick.AddListener(OnClickMainMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMainMenu() {
        SceneManager.LoadScene("MenuScenes");
    }
}
