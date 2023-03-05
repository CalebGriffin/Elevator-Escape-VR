using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This will be called when the game starts.
    // Choose 3 random topics and 1 random question from each topic.
    // Then assigns the chosen questions and answers to the GVar script.
    public void QuestionSetup()
    {
        // Pick 3 random topics ensuring that they are all different.
        QuestionData.Topic[] topics = new QuestionData.Topic[3];
        topics[0] = RandomTopic(null);
        topics[1] = RandomTopic(topics);
        topics[2] = RandomTopic(topics);

        // For each topic, pick a random question.
        QuestionData[] questions = new QuestionData[3];
        for (int i = 0; i < 3; i++)
        {
            questions[i] = RandomQuestion(topics[i], GVar.Instance.chosenDifficulty);
        }

        // Assign the chosen questions and answers to the GVar script.
        GVar.Instance.chosenQuestions = questions;
        GVar.Instance.chosenAnswers = questions.Select(q => q.Answer).ToArray();

        // Setup the question images.
        SetupQuestionImages();
    }

    QuestionData.Topic RandomTopic(QuestionData.Topic[] topicsToExclude, int loopCount = 0)
    {
        // If this function has looped too many times, throw an exception.
        if (loopCount > 1000)
            throw new System.Exception("RandomTopic() looped too many times. Check that the topicsToExclude array is not null or contains all topics.");
        
        // Pick a random topic.
        QuestionData.Topic randomTopic = (QuestionData.Topic)Random.Range(0, (int)QuestionData.Topic.COUNT);

        // If the topicsToExclude array is not null, check if the random topic is in the array.
        // If it is, pick a new random topic.
        if (topicsToExclude != null)
        {
            foreach (QuestionData.Topic topic in topicsToExclude)
            {
                if (randomTopic == topic)
                {
                    randomTopic = RandomTopic(topicsToExclude, loopCount + 1);
                }
            }
        }

        return randomTopic;
    }

    QuestionData RandomQuestion(QuestionData.Topic topic, int difficulty)
    {
        // Filter the questions array to only include questions with the given topic.
        QuestionData[] topicQuestions = GVar.Instance.AllQuestions.Where(q => q.QuestionTopic == topic).ToArray();

        // Filter the topicQuestions array to only include questions with the given difficulty.
        QuestionData[] difficultyQuestions = topicQuestions.Where(q => q.QuestionDifficulty == difficulty).ToArray();

        // Pick a random question from the difficultyQuestions array.
        return difficultyQuestions[Random.Range(0, difficultyQuestions.Length)];
    }

    private void SetupQuestionImages()
    {
        // TODO: Create canvas images for each question and assign the question images to them.
    }
}