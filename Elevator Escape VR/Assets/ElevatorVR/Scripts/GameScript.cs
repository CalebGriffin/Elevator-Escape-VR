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

    //Elevator lights for control.
    [SerializeField] private List<Light> elevatorLights;

    //Keypad to clear when resetting.
    [SerializeField] private KeypadScript keypad;


    //Whiteboard Marker and Whiteboards to clear.
    [SerializeField] private List<WhiteboardScript> whiteboards;

    //Questions to fill out.

    private void ResetGame()
    {

        Countdown = 60;
        CountdownSegment.text = Countdown.ToString();

        foreach (WhiteboardScript whiteboard in whiteboards)
            whiteboard.clearWhiteboard();

        //Begin countdown of elevator tick, after cancelling any currently running coroutine.
        if(ElevatorLoop != null)
            StopCoroutine(ElevatorLoop);

        ElevatorLoop = ElevatorTick();
        StartCoroutine(ElevatorLoop);
    }


    // Start is called before the first frame update
    void Start()
    {

        ResetGame();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //This will handle logics of counting down while also changing the elevator's environment based on remaining countdown.
    IEnumerator ElevatorTick()
    {
        while(Countdown > -1)
        {

            yield return new WaitForSeconds(1);

            Countdown--;
            CountdownSegment.text = Countdown.ToString();

        }

    }

    void setLights(Color lightColor, float intensity)
    {

        foreach (Light light in elevatorLights)
        {
            light.color = lightColor;
            light.intensity = intensity;
        }

    }

}
