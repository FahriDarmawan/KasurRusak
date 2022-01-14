using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour
{
    //tambah ini
    public BookPro book;

    public GameObject JournalUI;
    public GameObject GamePanel;

    //tambah 4 variabel ini
    public GameObject nextbutton;
    public GameObject prevbutton;
    public float collectedPaper;
    public float solvedPuzzle;

    //tambah ini 4 baris
    [Header("Stats Slider")]
    public Slider journalslider;
    public Slider puzzleslider;
    public Slider progressslider;

    private static bool isOpen = false;

    private static Journal _instance = null;
    public static Journal Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Journal>();
            }

            return _instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
                CloseJournal();
            else
                OpenJournal();
        }

        //4 baris
        journalslider.value = collectedPaper * 100 / 3;
        puzzleslider.value = solvedPuzzle * 100 / 4;
        progressslider.value = (journalslider.value + puzzleslider.value) / 2;
        JournalRules();
    }

    //2 baris
    public float CollectedPaper() => collectedPaper = collectedPaper + 1;
    public float SolvedPuzzle() => solvedPuzzle = solvedPuzzle + 1;

    //fungsi ini
    public void JournalRules()
    {
        if (collectedPaper == 0)
        {
            if (book.currentPaper == 1)
            {
                nextbutton.SetActive(true);
                prevbutton.SetActive(false);
            }
            else
            {
                nextbutton.SetActive(false);
                prevbutton.SetActive(true);
            }
        }
        else if (collectedPaper == 1)
        {
            if (book.currentPaper == 3)
            {
                nextbutton.SetActive(false);
                prevbutton.SetActive(true);
            }
            else if (book.currentPaper == 1)
            {
                prevbutton.SetActive(false);
            }
            else
            {
                nextbutton.SetActive(true);
                prevbutton.SetActive(true);
            }
        }
        else if (collectedPaper == 2)
        {
            if (book.currentPaper == 4)
            {
                nextbutton.SetActive(false);
                prevbutton.SetActive(true);
            }
            else if (book.currentPaper == 1)
            {
                prevbutton.SetActive(false);
            }
            else
            {
                nextbutton.SetActive(true);
                prevbutton.SetActive(true);
            }
        }
        else if (collectedPaper == 3)
        {
            if (book.currentPaper == 5)
            {
                nextbutton.SetActive(false);
                prevbutton.SetActive(true);
            }
            else if (book.currentPaper == 1)
            {
                prevbutton.SetActive(false);
            }
            else
            {
                nextbutton.SetActive(true);
                prevbutton.SetActive(true);
            }
        }
    }

    public void OpenJournal()
    {
        JournalUI.SetActive(true);
        GamePanel.SetActive(false);
        enableFPS(false);
        isOpen = true;
        TextJournal.Instance.ShowOption();
    }

    public void CloseJournal()
    {
        JournalUI.SetActive(false);
        GamePanel.SetActive(true);
        enableFPS(true);
        isOpen = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void enableFPS(bool enable)
    {
        GameObject fpsObj = GameObject.Find("FPSController");
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsScript = fpsObj.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        if (enable)
        {
            //Enable FPS script
            fpsScript.enabled = true;
        }
        else
        {
            //Disable FPS script
            fpsScript.enabled = false;
            //Unlock Mouse and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
