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

    public string PlayerName = "";

    [SerializeField] private List<QuestionData> allQuestions = new List<QuestionData>();
    public List<QuestionData> AllQuestions => allQuestions;

    // TODO: Hide all of these from the inspector.
    public QuestionData[] ChosenQuestions;

    public string[] ChosenAnswers;

    public QuestionData.Difficulty ChosenDifficulty = QuestionData.Difficulty.D;

    public int QuestionsAnswered = 0;

    public ScoreData ScoreData;
}
