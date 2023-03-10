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

    // TODO: Hide all of these from the inspector.
    public QuestionData[] ChosenQuestions;

    public int[] ChosenAnswers;

    public QuestionData.Difficulty ChosenDifficulty;

    public int QuestionsAnswered = 0;
}
