using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject TBC;
    private Text conversation;
    private Text tbcText;
    public AudioClip soundMagi01;
    public AudioClip soundMagi02;
    public AudioClip soundMagi03;
    AudioSource audioSource;

    private void Awake()
    {
        conversation = TextBox.GetComponent<Text>();
        tbcText = TBC.GetComponent<Text>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(EndingScene());
    }

    IEnumerator EndingScene()
    {
        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(soundMagi01, 0.2f);
        TextWriter.AddWriter_Static(conversation, "Magi : Hah! Sepertinya aku terlalu meremehkan kamu Anwar! Mungkin kamu memang benar-benar ingin berubah, ingin menjadi manusia yang “lebih baik” dari yang saat ini.", .01f, true);
        yield return new WaitForSeconds(15);

        audioSource.PlayOneShot(soundMagi02, 0.2f);
        TextWriter.AddWriter_Static(conversation, "Magi :Semangatmu terlihat sangat jelas, baiklah! Aku akan memberikan kamu sebuah momento dari guru favoritmu!", .01f, true);
        yield return new WaitForSeconds(11);

        audioSource.PlayOneShot(soundMagi03, 0.2f);
        TextWriter.AddWriter_Static(conversation, "Magi : Tapi! Perjalananmu belum berakhir Anwar!", .01f, true);
        yield return new WaitForSeconds(5);
        conversation.text = "";

        TextWriter.AddWriter_Static(tbcText, "To Be Continue...", .2f, true);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Menu_Scene");
    }
}
