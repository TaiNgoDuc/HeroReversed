using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{

    [SerializeField] PlayerScript dragonPrefab;
    [SerializeField] PlayerScript wizardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.currentPlayer == TypePlayer.DRAGON ) {
            GameManager.Instance.player = Instantiate(dragonPrefab,new Vector3 (-8.28f, -1.65f, 0f), Quaternion.identity); 
            // GameManager.Instance.player = gameObject.GetComponent<PlayerScript>();

        } else{
            GameManager.Instance.player = Instantiate(wizardPrefab,new Vector3 (-8.28f, -1.65f, 0f), Quaternion.identity);
            // GameManager.Instance.player = gameObject.GetComponent<PlayerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
