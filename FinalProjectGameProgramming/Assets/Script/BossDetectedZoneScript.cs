using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectedZoneScript : MonoBehaviour
{

    public static BossDetectedZoneScript Instance;
    private int detectZone;
    public bool detected = false;
    public int getDetectZone{ 
        get 
        {
            return detectZone;
        } 
        set
        {
            detectZone = value;
        }}

    public void Awake() {
        if (!Instance) {
            Instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            detected = true;
            detectZone = Random.Range(0,2);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            detected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
