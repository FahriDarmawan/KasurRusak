using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObject : MonoBehaviour
{
    public float TheDistance;
    public GameObject TextBox;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            TextBox.GetComponent<Text>().fontStyle = FontStyle.Normal;
            TextBox.GetComponent<Text>().text = "Huh, aku perlu mengingat bunga ini untuk jaga-jaga";
        }
    }

    private void OnMouseExit()
    {
        TextBox.GetComponent<Text>().text = "";
    }
}
