using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{

    private IEnumerator ElevatorLoop;

    //Countdown floor display.
    private int Countdown = 60;
    [SerializeField] private TextMeshProUGUI CountdownSegment;

    [SerializeField] private TextMeshProUGUI winText;

    //Elevator lights for control.
    [SerializeField] private ElevatorLightScript elevatorLights;

    //Keypad to clear when resetting.
    [SerializeField] private KeypadScript keypad;

    [SerializeField] private ScoreManager scoreManager;


    //Whiteboard Marker and Whiteboards to clear.
    [SerializeField] private List<WhiteboardScript> whiteboards;

    // Question Canvas Objects to enable/disable
    [SerializeField] private List<GameObject> questionCanvases;

    // Leaderboard Canvas Object
    [SerializeField] private GameObject leaderboardCanvas;

    // Left Wall Stuff Object
    [SerializeField] private GameObject leftWallStuff;

    // Right Wall Stuff Object
    [SerializeField] private GameObject rightWallStuff;

    //Questions to fill out.

    private void ResetGame()
    {
        // Disable the Leaderboards, difficulty selector, name input and start button
        leaderboardCanvas.SetActive(false);
        leftWallStuff.SetActive(false);
        rightWallStuff.SetActive(false);

        // Enable the whiteboards
        foreach (WhiteboardScript whiteboard in whiteboards)
            whiteboard.gameObject.SetActive(true);

        // Enable the question canvases
        foreach (GameObject questionCanvas in questionCanvases)
            questionCanvas.SetActive(true);

        NameInput.Instance.Enter();

        Countdown = 180;
        UpdateCountdownText();

        keypad.onClear();

        foreach (WhiteboardScript whiteboard in whiteboards)
            whiteboard.clearWhiteboard();

        //Begin countdown of elevator tick, after cancelling any currently running coroutines.
        if(ElevatorLoop != null)
            StopCoroutine(ElevatorLoop);

        ElevatorLoop = ElevatorTick();
        StartCoroutine(ElevatorLoop);

        elevatorLights.resetLights();

        winText.text = "";
    }


    // This will be called to start the game
    public void StartGame()
    {

        ResetGame();

    }

    private void ResetMenu()
    {
        NameInput.Instance.Clear();

        // Disable the whiteboards
        foreach (WhiteboardScript whiteboard in whiteboards)
            whiteboard.gameObject.SetActive(false);
        
        // Disable the question canvases
        foreach (GameObject questionCanvas in questionCanvases)
            questionCanvas.SetActive(false);

        // Enable the Leaderboard, difficultly selector, name input and start button
        leaderboardCanvas.SetActive(true);
        leftWallStuff.SetActive(true);
        rightWallStuff.SetActive(true);
    }

    public void Win()
    {
        // Add the score to the leaderboard
        scoreManager.AddScore(new Score(GVar.Instance.PlayerName, 180 - Countdown));
        scoreManager.SaveScores();

        // Display win text
        winText.text = "You Win!";

        // Reset the game
        ResetMenu();
    }

    public void Lose()
    {
        // Display lose text
        winText.text = "You Lose!";

        // Reset the game
        ResetMenu();
    }

    //This will handle logics of counting down while also changing the elevator's environment based on remaining countdown.
    IEnumerator ElevatorTick()
    {
        while(Countdown > 0)
        {

            yield return new WaitForSeconds(1);

            Countdown--;
            UpdateCountdownText();

            switch (Countdown)
            {
                case 0:
                    Lose();
                    break;
                /*
                case 10:
                    elevatorLights.setFlicker(0.0f, 0.1f, 0.0f, 0.2f, Color.red, 0.1f);
                    break;
                */
                case 30:
                    elevatorLights.setFlicker(0.1f, 0.5f, 0.1f, 0.4f, Color.red, 0.2f);
                    break;
                
                case 60:
                    elevatorLights.setFlicker(1.25f, 3.75f, 0.25f, 0.625f, new Color(0.9f, 0.5f, 0.0f), 0.3f);
                    break;
                
                case 120:
                    elevatorLights.setFlicker(5.0f, 15.0f, 0.45f, 0.75f, Color.white, 0.4f);
                    break;
                
                default:
                    elevatorLights.resetLights();
                    break;
            }
        }

    }

    private void UpdateCountdownText()
    {
        string minutes = Mathf.Floor(Countdown / 60).ToString("00");
        string seconds = (Countdown % 60).ToString("00");
        CountdownSegment.text = minutes + ":" + seconds;
    }

}
