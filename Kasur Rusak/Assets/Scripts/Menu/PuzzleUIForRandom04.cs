using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUIForRandom04 : MonoBehaviour
{
    public GameObject puzzleUI;
    public GameObject GamePanel;
    public Text c1;
    public Text c2;
    public Text c3;
    //public Text c4;

    #region Singleton

    private static PuzzleUIForRandom04 _instance = null;

    public static PuzzleUIForRandom04 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PuzzleUIForRandom04>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    private void Update()
    {
        c1.text = InteractionForRandom04.Instance.Counter1.ToString();
        c2.text = InteractionForRandom04.Instance.Counter2.ToString();
        c3.text = InteractionForRandom04.Instance.Counter3.ToString();
        //c4.text = Interaction.Instance.Counter4.ToString();
    }

    public void Puzzle()
    {
        GamePanel.SetActive(false);
        enableFPS(false);
        puzzleUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitPuzzle()
    {
        GamePanel.SetActive(true);
        puzzleUI.SetActive(false);
        enableFPS(true);
        Time.timeScale = 1f;
    }

    public void C1Up()
    {
        InteractionForRandom04.Instance.Counter1Up();
    }

    public void C2Up()
    {
        InteractionForRandom04.Instance.Counter2Up();
    }

    public void C3Up()
    {
        InteractionForRandom04.Instance.Counter3Up();
    }
    
    public void C1Down()
    {
        InteractionForRandom04.Instance.Counter1Down();
    }
    
    public void C2Down()
    {
        InteractionForRandom04.Instance.Counter2Down();
    }
    
    public void C3Down()
    {
        InteractionForRandom04.Instance.Counter3Down();
    }

    public void Submit ()
    {
        InteractionForRandom04.Instance.CheckPuzzle();
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
