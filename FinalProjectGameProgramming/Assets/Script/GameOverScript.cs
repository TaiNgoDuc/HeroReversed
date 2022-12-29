using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] Button startAgainButton;

    // Start is called before the first frame update
        void Awake()
    {
        startAgainButton.onClick.AddListener(OnClickStartAgain);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartAgain() {
        SceneManager.LoadScene("MenuScenes");
    }

}
