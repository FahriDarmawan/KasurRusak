using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPaper : MonoBehaviour
{
    public GameObject paper;
    public float TheDistance;
    public GameObject floatText;
    public AudioSource collectPapersfx;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {
            floatText.SetActive(true);
        } 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Journal.Instance.CollectedPaper();
            collectPapersfx.Play();
            Destroy(paper);
        }
    }

    private void OnMouseExit()
    {
        floatText.SetActive(false);
    }
}
