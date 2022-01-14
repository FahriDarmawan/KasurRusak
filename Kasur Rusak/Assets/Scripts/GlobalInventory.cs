using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalInventory : MonoBehaviour
{
    [Header ("Door System")]
    [SerializeField] private LockedDoor door01;
    [SerializeField] private LockedDoor02 door02;
    public GameObject Key;
    [SerializeField] public AudioSource BGM01;
    [SerializeField] public AudioSource BGM02;

    [Header("UI")]
    public GameObject text01;
    public GameObject text02;
    public GameObject text03;

    [Header("GamePlay UI")]
    public GameObject paperCollectNum;
    public GameObject puzzleSolvedNum;

    [Header("Item Drop System")]
    [SerializeField] private DropZoneTrigger01 zone01;
    [SerializeField] private DropZoneTrigger02 zone02;
    [SerializeField] private DropZoneTrigger03 zone03;
    [SerializeField] private Journal journal;
    public Transform mementoSpawn;

    [Header("Ending")]
    public GameObject TextBox;
    public GameObject memento;
    public GameObject mementoCheck;
    public GameObject fadeToBlack;
    public GameObject Player;
    public GameObject CanvasJournal;
    

    private void Update()
    {
        Key = GameObject.Find("FPSController/FirstPersonCharacter/GrabSlot/Key(Clone)");
        mementoCheck = GameObject.Find("FPSController/FirstPersonCharacter/GrabSlot/Apple 1(Clone)");

        paperCollectNum.GetComponent<Text>().text = journal.collectedPaper.ToString();
        puzzleSolvedNum.GetComponent<Text>().text = journal.solvedPuzzle.ToString();


        if(door01.isOpen == true && door02.isOpen == true)
        {
            Destroy(Key);
            BGM01.GetComponent<AudioSource>().volume = 0;
            BGM02.GetComponent<AudioSource>().volume = 0.1f;
            text01.SetActive(true);
            text02.SetActive(true);
            text03.SetActive(true);
        }

        if (zone01.isTrigger == true && zone02.isTrigger == true && zone03.isTrigger == true && journal.collectedPaper == 3)
        {
            Instantiate(memento, mementoSpawn, mementoSpawn);
            StartCoroutine(Text());
            zone01.isTrigger = false;
            zone02.isTrigger = false;
            zone03.isTrigger = false;
        }

        if(mementoCheck)
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            CanvasJournal.GetComponent<Journal>().enabled = false;
            fadeToBlack.SetActive(true);
            SceneManager.LoadScene("Ending");
        }
    }

    IEnumerator Text()
    {
        TextBox.GetComponent<Text>().text = "Memento Spawned";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
    }
}
