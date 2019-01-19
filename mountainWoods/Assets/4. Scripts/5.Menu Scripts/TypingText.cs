using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    Text text;
    float timer;
    public float timeDuration;

    string originalText;
    int index = 0;

    void Start()
    {
        text = GetComponent<Text>();
        timer = timeDuration;
        originalText = text.text;
        text.text = ""; //Making it empty because we dont want the text to appear in the begining
    }

    public void SetText(string myText)
    {
        originalText = myText;
        text.text = "";
        timer = timeDuration;
        index = 0;
    }

    void Update()
    {
        if (index < originalText.Length)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            text.text += originalText[index];
            timer = timeDuration;
            index++;
        }
    }
}