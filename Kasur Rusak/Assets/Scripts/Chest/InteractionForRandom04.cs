using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionForRandom04 : MonoBehaviour
{
    [SerializeField] PuzzleType puzzleType;
    //[SerializeField] Chest chest;
    //public List<GameObject> chest;
    public Animator chestAnimator;
    public GameObject text;
    public float Distance;
    //public Text puzzleTitle;

    bool Open = false;
    bool isTrigger = false;
    bool isSolved = false;
    bool con = false;

    int counter1 = 0;
    int counter2 = 0;
    int counter3 = 0;

    public AudioSource JumpscareSFX;
    public GameObject Player;
    public GameObject JumpscareCam;
    public GameObject FlickeringImg;
    public GameObject GameOverPanel;
    public GameObject CanvasJournal;
    public GameObject GamePanel;
    //public Transform itemSlot;

    #region Singleton

    private static InteractionForRandom04 _instance = null;

    public static InteractionForRandom04 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InteractionForRandom04>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    public int Counter1 { get { return counter1; } }
    public int Counter2 { get { return counter2; } }
    public int Counter3 { get { return counter3; } }

    public int Counter1Up()
    {
        if (counter1 < 9)
            return counter1++;
        else
            return counter1;
    }

    public int Counter2Up()
    {
        if (counter2 < 9)
            return counter2++;
        else
            return counter2;
    }

    public int Counter3Up()
    {
        if (counter3 < 9)
            return counter3++;
        else
            return counter3;
    }

    public int Counter1Down()
    {
        if (counter1 > 0)
            return counter1--;
        else
            return counter1;
    }

    public int Counter2Down()
    {
        if (counter2 > 0)
            return counter2--;
        else
            return counter2;
    }

    public int Counter3Down()
    {
        if (counter3 > 0)
            return counter3--;
        else
            return counter3;
    }

    private void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                openPuzzle();
                enableFPS(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            if (isSolved == false)
                text.SetActive(true);
            else
                text.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
            text.SetActive(false);
        }
    }

    private void openPuzzle()
    {
        
        if (con == false)
        {
            PuzzleUIForRandom04.Instance.Puzzle();
            con = true;
        }
        else
        {
            PuzzleUIForRandom04.Instance.QuitPuzzle();
            con = false;
        }
    }

    public void CheckPuzzle()
    {
        if (puzzleType == PuzzleType.Puzzle01)
        {
            if (Counter1 == 2 && Counter2 == 3 && Counter3 == 4)
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
            else
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            } 
        } 
        else if (puzzleType == PuzzleType.Puzzle02)
        {
            if (Counter1 == 4 && Counter2 == 3 && Counter3 == 4)
            {
                Open = !Open;
                chestAnimator.SetBool("Open", Open);
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                Journal.Instance.SolvedPuzzle();
                Debug.Log("BENAR");
                isSolved = true;
                enableFPS(true);
            }
            else
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
        }
        else if (puzzleType == PuzzleType.Puzzle03)
        {
            if (Counter1 == 3 && Counter2 == 4 && Counter3 == 3)
            {
                Open = !Open;
                chestAnimator.SetBool("Open", Open);
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                Journal.Instance.SolvedPuzzle();
                Debug.Log("BENAR");
                isSolved = true;
                enableFPS(true);
            }
            else
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
        }
        else if (puzzleType == PuzzleType.Puzzle04)
        {
            if (Counter1 == 2 && Counter2 == 4 && Counter3 == 4)
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
            else
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
        }
        else if (puzzleType == PuzzleType.Puzzle05)
        {
            if (Counter1 == 5 && Counter2 == 4 && Counter3 == 2)
            {
                Open = !Open;
                chestAnimator.SetBool("Open", Open);
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                Journal.Instance.SolvedPuzzle();
                Debug.Log("BENAR");
                isSolved = true;
                enableFPS(true);
            }
            else
            {
                PuzzleUIForRandom04.Instance.QuitPuzzle();
                //Time.timeScale = 0f;
                StartCoroutine(Jumpscare());
                Debug.Log("SALAH");
                GameOverPanel.SetActive(true);
                enableFPS(false);
                CanvasJournal.GetComponent<Journal>().enabled = false;
            }
        }
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

    IEnumerator Jumpscare()
    {
        GamePanel.SetActive(false);
        JumpscareSFX.Play();
        JumpscareCam.SetActive(true);
        Player.SetActive(false);
        FlickeringImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Player.SetActive(true);
        JumpscareCam.SetActive(false);
        FlickeringImg.SetActive(false);
    }
}
