using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    [SerializeField] private List<QuestionData> allQuestions = new List<QuestionData>();
    public List<QuestionData> AllQuestions => allQuestions;

    // TODO: Hide all of these from the inspector.
    public QuestionData[] ChosenQuestions;

    public string[] ChosenAnswers;

    public QuestionData.Difficulty ChosenDifficulty;

    public int QuestionsAnswered = 0;

    private void Start()
    {
        string[] assetNames = AssetDatabase.FindAssets("t:QuestionData", new[] {"Assets/ElevatorVR/Questions"});
        allQuestions.Clear();
        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var questionData = AssetDatabase.LoadAssetAtPath<QuestionData>(SOpath);
            allQuestions.Add(questionData);
        }
    }
}
