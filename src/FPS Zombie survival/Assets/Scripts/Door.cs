using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag =="Player" && PlayerManagement.singleton.keyCount > 0){
            PlayerManagement.singleton.keyCount--;
            print("You opened the door!");
            Destroy(gameObject);
        }
        else{
            print("The door is locked, please find the key!");
        }
    }
}
