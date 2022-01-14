using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneTrigger03 : MonoBehaviour
{
    public bool isTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            isTrigger = true;
            Debug.Log("Item Masuk Zone03");
        }
    }
}
