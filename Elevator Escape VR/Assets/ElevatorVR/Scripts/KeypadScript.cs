using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{
    [SerializeField] private GameScript gameScript;

    [SerializeField] private TextMeshProUGUI KeypadSegment;

    [SerializeField] AudioSource audioScr;
    [SerializeField] AudioClip ButtonDing;
    [SerializeField] AudioClip WinSound;
    [SerializeField] AudioClip BadSound;

    private bool isEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPress(string digit) {

        if (!isEnabled) return;

        KeypadSegment.text = KeypadSegment.text + digit;
        audioScr.PlayOneShot(ButtonDing, 1F);
        Debug.Log("DINGDINGDING");

    }

    public void onClear()
    {
        KeypadSegment.text = "";
        isEnabled = true;
    }

    public void onBackspace()
    {
        if (!isEnabled) return;

        if (KeypadSegment.text.Length > 0)
        {
            KeypadSegment.text = KeypadSegment.text.Substring(0, KeypadSegment.text.Length - 1);
        }
    }

    public void onConfirm()
    {
        if (KeypadSegment.text == GVar.Instance.ChosenAnswers[GVar.Instance.QuestionsAnswered])
        {
            GVar.Instance.QuestionsAnswered++;
            KeypadSegment.text = "Correct!";
            isEnabled = false;
            if (GVar.Instance.QuestionsAnswered == 3)
            {
                // The player has answered all 3 questions correctly and the game is over.
                // TODO: End the game by opening the elevator door.
                gameScript.Win();
                audioScr.clip = WinSound;
                isEnabled = true;
            }
            else
            {
                // The player answered correctly but there are still more questions to answer.
                StartCoroutine(WaitToClear(2));
            }
        }
        else
        {
            // The player answered incorrectly.
            KeypadSegment.text = "Incorrect!";
            audioScr.clip = BadSound;
            StartCoroutine(WaitToClear());
        }
    }

    private IEnumerator WaitToClear(float waitTime = 1)
    {
        yield return new WaitForSeconds(waitTime);
        onClear();
    }
}
