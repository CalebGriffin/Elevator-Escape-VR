using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI KeypadSegment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPress(string digit) {

        KeypadSegment.text = KeypadSegment.text + digit;

    }

    public void onClear()
    {
        KeypadSegment.text = "";
    }

    public void onConfirm()
    {

    }

}
