using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacter);
    }

    private void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacter));
    }

    private void Update()
    {
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if(destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacter;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacter)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacter = invisibleCharacter;
            characterIndex = 0;
        }


        //Return true on complete
        public bool Update()
        {
           timer -= Time.deltaTime;
           while (timer <= 0f)
           {             
                //Display next Character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacter)
                {
                   text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    //entire sring displayed
                    return true;
                }
           }

            return false;
            
        }
    }
}
