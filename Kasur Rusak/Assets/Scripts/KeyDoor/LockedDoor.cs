using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject textAction;
    public AudioSource lockedDoor;
    public AudioSource openDoor;
    public GameObject parentKey;
    public GameObject door;
    GlobalInventory globalInventory;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            textAction.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                textAction.SetActive(false);
                StartCoroutine(Door());
            }
        }
    }

    private void OnMouseExit()
    {
        textAction.SetActive(false);
    }


    IEnumerator Door()
    {
        if(parentKey.transform.Find("Key(Clone)"))
        {
            isOpen = true;
            door.GetComponent<Animator>().Play("DoorOpen01");
            openDoor.Play();
            yield return new WaitForSeconds(1.1f);
            this.GetComponent<BoxCollider>().enabled = false;
        } 
        else
        {
            lockedDoor.Play();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
