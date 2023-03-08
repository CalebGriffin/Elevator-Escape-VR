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
    [SerializeField] private ElevatorLightScript elevatorLights;

    //Keypad to clear when resetting.
    [SerializeField] private KeypadScript keypad;


    //Whiteboard Marker and Whiteboards to clear.
    [SerializeField] private List<WhiteboardScript> whiteboards;

    //Questions to fill out.

    private void ResetGame()
    {

        Countdown = 180;
        CountdownSegment.text = Countdown.ToString();

        keypad.onClear();

        foreach (WhiteboardScript whiteboard in whiteboards)
            whiteboard.clearWhiteboard();

        //Begin countdown of elevator tick, after cancelling any currently running coroutines.
        if(ElevatorLoop != null)
            StopCoroutine(ElevatorLoop);

        ElevatorLoop = ElevatorTick();
        StartCoroutine(ElevatorLoop);

        elevatorLights.resetLights();

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
        while(Countdown > 0)
        {

            yield return new WaitForSeconds(1);

            Countdown--;
            CountdownSegment.text = Countdown.ToString();

            //if(Countdown == 10)
            //    elevatorLights.setFlicker(0.0f, 0.1f, 0.0f, 0.2f, Color.red, 0.1f);
            if (Countdown == 30)
                elevatorLights.setFlicker(0.1f, 0.5f, 0.1f, 0.4f, Color.red, 0.2f);
            else if (Countdown == 60)
                elevatorLights.setFlicker(1.25f, 3.75f, 0.25f, 0.625f, new Color(0.9f, 0.5f, 0.0f), 0.3f);
            else if (Countdown == 120)
                elevatorLights.setFlicker(5.0f, 15.0f, 0.45f, 0.75f, Color.white, 0.4f);
            else if(Countdown > 120)
                elevatorLights.resetLights();

        }

    }

}
