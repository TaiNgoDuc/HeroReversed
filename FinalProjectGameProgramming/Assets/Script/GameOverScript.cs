using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] Button startAgainButton;
    public static GameManager Instance;

    IEnumerator LoadMainMenu() {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("MenuScenes");
    }

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
        GameManager.Instance.playSoundStartAgainbtn();
        StartCoroutine(LoadMainMenu());
    }

}
