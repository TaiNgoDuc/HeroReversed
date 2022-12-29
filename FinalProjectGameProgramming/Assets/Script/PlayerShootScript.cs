using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{

    public Transform shootPosition;
    public GameObject fireballPrefab;

    public void playerShoot() {
        GameObject fireBallShoot = Instantiate(fireballPrefab, shootPosition.position, fireballPrefab.transform.rotation);

        Vector3 fireballPosition = fireBallShoot.transform.localScale;
        fireBallShoot.transform.localScale = new Vector3(
            fireballPosition.x * transform.localScale.x > 0 ? 1 : -1,
            fireballPosition.y, 
            fireballPosition.z
        );
    }


    
}
