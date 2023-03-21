using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultySetter : MonoBehaviour
{
    private string[] difficultyChars = new string[] {"A", "B", "C", "D"};

    [SerializeField] private TextMeshProUGUI difficultyText;

    public void SetDifficulty(int difficulty)
    {
        GVar.Instance.ChosenDifficulty = (QuestionData.Difficulty) difficulty;

        difficultyText.text = "Selected Difficulty: " + difficultyChars[difficulty];
    }
}
