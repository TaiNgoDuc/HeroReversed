using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public void Awake()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GameManager.Instance.player.transform.position.x+5, transform.position.y, transform.position.z);
    }

    // private void LateUpdate() {
        
    //     if (GameManager.Instance.currentPlayer == TypePlayer.DRAGON ) {
    //         transform.position = new Vector3(player.transform.position.x+5, transform.position.y, transform.position.z);

    //     } else{
    //         transform.position = new Vector3(player.transform.position.x+5, transform.position.y, transform.position.z);
    //     }
    // }

    
}
