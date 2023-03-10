using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "QuestionData", order = 0)]
public class QuestionData : ScriptableObject
{
    // This enum is used to categorize questions into topics.
    // The COUNT value is used to get the number of topics for randomisation.
    public enum Topic
    {
        Coordinates, Algebra, Geometry, COUNT
    }

    // Each value is private and serialized so that it can be set from the Unity editor.
    // Each value also has a public getter so that it can be accessed from other scripts.
    [SerializeField] private Sprite questionImage;
    public Sprite QuestionImage => questionImage;

    [SerializeField] private int answer;
    public int Answer => answer;

    [SerializeField] private Topic questionTopic;
    public Topic QuestionTopic => questionTopic;

    // This enum is used to categorize questions into difficulty levels.
    public enum Difficulty
    {
        A, B, C, D
    }

    [SerializeField] private Difficulty questionDifficulty;
    public Difficulty QuestionDifficulty => questionDifficulty;
}
