using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreen;
    public GameObject CanvasJournal;
    public GameObject TextBox;
    public GameObject GameUIPanel;
    private Text conversation;
    public AudioClip Anwar01, Anwar02, Anwar03, Anwar04, Anwar05;
    public AudioClip Magi01, Magi02, Magi03, Magi04, Magi05, Magi06, Magi07;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        CanvasJournal.GetComponent<Journal>().enabled = false;
        GameUIPanel.SetActive(false);
        audio = GetComponent<AudioSource>();
        StartCoroutine(OpeningScene());
    }

    private void Awake()
    {
        conversation = TextBox.GetComponent<Text>();
    }

    IEnumerator OpeningScene()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreen.SetActive(false);
        conversation.fontStyle = FontStyle.Normal;
        audio.PlayOneShot(Anwar01);
        TextWriter.AddWriter_Static(conversation, "Anwar : Di... dimana ini? Sama seperti sekolah ku, tapi... kok tidak terurus?", .01f, true);
        yield return new WaitForSeconds(6f);

        conversation.fontStyle = FontStyle.Italic;
        audio.PlayOneShot(Magi01);
        TextWriter.AddWriter_Static(conversation, "Magi : Kamu ada di duniaku", .01f, true);
        yield return new WaitForSeconds(3f);

        conversation.fontStyle = FontStyle.Normal;
        audio.PlayOneShot(Anwar02);
        TextWriter.AddWriter_Static(conversation, "Anwar : Aku tidak paham...", .01f, true);
        yield return new WaitForSeconds(2f);

        conversation.fontStyle = FontStyle.Italic;
        audio.PlayOneShot(Magi02);
        TextWriter.AddWriter_Static(conversation, "Magi : Jadi begini, kamu kira aku akan melepaskan kamu begitu saja? Dengan bergaul dengan manusia biasa?! Hah! Tidak akan!", .01f, true);
        yield return new WaitForSeconds(13f);
        audio.PlayOneShot(Magi03);
        TextWriter.AddWriter_Static(conversation, "Magi : Kamu akan tinggal di dunia ini dan itu keputusan finalku!", .01f, true);
        yield return new WaitForSeconds(5f);

        conversation.fontStyle = FontStyle.Normal;
        audio.PlayOneShot(Anwar03);
        TextWriter.AddWriter_Static(conversation, "Anwar : Magi… aku tidak bisa berada disini. Kamu tahu aku manusia biasa sama seperti Asih dan yang lain.", .01f, true);
        yield return new WaitForSeconds(8f);
        audio.PlayOneShot(Anwar04);
        TextWriter.AddWriter_Static(conversation, "Anwar : Maafkan aku Magi, tapi aku tidak ingin tinggal disini.", .01f, true);
        yield return new WaitForSeconds(4f);

        conversation.fontStyle = FontStyle.Italic;
        audio.PlayOneShot(Magi04);
        TextWriter.AddWriter_Static(conversation, "Magi : Heh, kalau begitu buktikan padaku kalau kamu benar-benar memaafkan manusia atas apa yang terjadi dengan ibumu!", .01f, true);
        yield return new WaitForSeconds(9f);
        audio.PlayOneShot(Magi05);
        TextWriter.AddWriter_Static(conversation, "Magi : Aku telah menyembunyikan beberapa barang yang perlu kamu kumpulkan, pertama coba kamu lihat jurnal yang ada di kantongmu. Setiap lembaran yang hilang itu adalah catatan yang paling penting bagimu, kamu perlu menemukan semua lembaran kertas ampas itu.", .01f, true);
        yield return new WaitForSeconds(20f);
        audio.PlayOneShot(Magi06);
        TextWriter.AddWriter_Static(conversation, "Magi : Dan aku menantang kamu untuk mengumpulkan barang-barang milik manusia yang kamu anggap berharga itu. Eww…", .01f, true);
        yield return new WaitForSeconds(8f);

        conversation.fontStyle = FontStyle.Normal;
        audio.PlayOneShot(Anwar05);
        TextWriter.AddWriter_Static(conversation, "Anwar : Barang? Seperti apa?", .01f, true);
        yield return new WaitForSeconds(3f);

        conversation.fontStyle = FontStyle.Italic;
        audio.PlayOneShot(Magi07);
        TextWriter.AddWriter_Static(conversation, "Magi : Ah nanti juga kamu tau kalau sudah melihatnya.", .01f, true);
        yield return new WaitForSeconds(4f);
        conversation.text = "";

        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        CanvasJournal.GetComponent<Journal>().enabled = true;
        GameUIPanel.SetActive(true);

    }
}
