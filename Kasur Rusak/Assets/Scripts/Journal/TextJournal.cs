using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextJournal : MonoBehaviour
{
    private static TextJournal _instance = null;
    public static TextJournal Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TextJournal>();
            }

            return _instance;
        }
    }

    [Header("Panel")]
    public GameObject mainmenu;
    public GameObject journal;
    public GameObject stats;

    public void ShowOption()
    {
        
        mainmenu.SetActive(true);
        journal.SetActive(false);
        stats.SetActive(false);
    }

    public void ShowJournal()
    {
        
        mainmenu.SetActive(false);
        journal.SetActive(true);
        stats.SetActive(false);
    }
    
    public void ShowStats()
    {
        mainmenu.SetActive(false);
        journal.SetActive(false);
        stats.SetActive(true);
    }
}
