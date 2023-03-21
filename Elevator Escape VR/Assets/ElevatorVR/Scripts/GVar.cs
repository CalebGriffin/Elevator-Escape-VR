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

    public string PlayerName = "";

    [SerializeField] private List<QuestionData> allQuestions = new List<QuestionData>();
    public List<QuestionData> AllQuestions => allQuestions;

    // TODO: Hide all of these from the inspector.
    public QuestionData[] ChosenQuestions;

    public string[] ChosenAnswers;

    public QuestionData.Difficulty ChosenDifficulty = QuestionData.Difficulty.D;

    public int QuestionsAnswered = 0;

    public ScoreData ScoreData;

    private void Start()
    {
        allQuestions.Clear();

        string[] folderPaths = AssetDatabase.GetSubFolders("Assets/ElevatorVR/Questions");
        foreach (string folderPath in folderPaths)
        {
            GetQuestionAssets(folderPath);
        }
    }

    private void GetQuestionAssets(string folderPath)
    {
        string[] assetNames = AssetDatabase.FindAssets("t:QuestionData", new[] {folderPath});
        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var questionData = AssetDatabase.LoadAssetAtPath<QuestionData>(SOpath);
            allQuestions.Add(questionData);
        }
    }
}
