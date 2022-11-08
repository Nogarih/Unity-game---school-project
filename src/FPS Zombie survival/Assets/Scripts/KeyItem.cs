using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            PlayerManagement.singleton.keyCount += 1;
            print("You picked up a key!");
            Destroy(gameObject);
        }
    }
}
