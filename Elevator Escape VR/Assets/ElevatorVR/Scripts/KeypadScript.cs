using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI KeypadSegment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPress(string digit) {

        KeypadSegment.text = KeypadSegment.text + digit;

    }

    public void onClear()
    {
        KeypadSegment.text = "";
    }

    public void onBackspace()
    {
        if (KeypadSegment.text.Length > 0)
        {
            KeypadSegment.text = KeypadSegment.text.Substring(0, KeypadSegment.text.Length - 1);
        }
    }

    public void onConfirm()
    {
        if (KeypadSegment.text == GVar.Instance.ChosenAnswers[GVar.Instance.QuestionsAnswered].ToString())
        {
            GVar.Instance.QuestionsAnswered++;
            KeypadSegment.text = "Correct!";
            if (GVar.Instance.QuestionsAnswered == 3)
            {
                // The player has answered all 3 questions correctly and the game is over.
                // TODO: End the game by opening the elevator doors.
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
            StartCoroutine(WaitToClear());
        }
    }

    private IEnumerator WaitToClear(float waitTime = 1)
    {
        yield return new WaitForSeconds(waitTime);
        onClear();
    }
}
