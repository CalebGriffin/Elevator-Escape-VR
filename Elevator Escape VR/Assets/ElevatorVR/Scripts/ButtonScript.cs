using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonScript : MonoBehaviour
{

    private bool isPressed = false;
    private Transform Button;
    private GameObject Text;

    [SerializeField] private UnityEvent pressEvent;

    // Start is called before the first frame update
    void Start()
    {
        Button = transform.Find("Button");
        Text = transform.FindChildRecursive("Text").gameObject;
        Text.GetComponent<TextMeshProUGUI>().text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {

            if (Button != null)
                Button.position += new Vector3(0.0f, 0.0f, 0.0075f);

            pressEvent.Invoke();

            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {

            if (Button != null)
                Button.position += new Vector3(0.0f, 0.0f, -0.0075f);

            isPressed = false;
        }
    }
}
