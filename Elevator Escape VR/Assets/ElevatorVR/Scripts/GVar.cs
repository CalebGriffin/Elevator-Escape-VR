using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GVar : MonoBehaviour
{
    public static GVar Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private QuestionData[] allQuestions;
    public QuestionData[] AllQuestions => allQuestions;

    public QuestionData[] chosenQuestions;

    public int[] chosenAnswers;

    public int chosenDifficulty;

    public int questionsAnswered = 0;
}
