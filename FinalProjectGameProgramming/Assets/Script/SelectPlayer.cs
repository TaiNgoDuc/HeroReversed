using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{

    [SerializeField] Button Dragon;
    [SerializeField] Button GreenDragon;

    public void OnClickDragon() { 
        GameManager.Instance.currentPlayer = TypePlayer.DRAGON;
        SceneManager.LoadScene("Level1");
    }

    public void OnClickGreenDragon() { 
        GameManager.Instance.currentPlayer = TypePlayer.GREENDRAGON;
        SceneManager.LoadScene("Level1");
    }

    // Start is called before the first frame update
    void Start()
    {
        Dragon.onClick.AddListener(OnClickDragon);
        GreenDragon.onClick.AddListener(OnClickGreenDragon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
