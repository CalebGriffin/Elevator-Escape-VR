using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardCreator : MonoBehaviour
{
    private string[] characters = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Caps", "Back", "Clear", "Enter"};

    private int currentCharacter = 0;

    [SerializeField] private GameObject buttonPrefab;

    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private Vector3 xOffset = new Vector3(0.15f, 0, 0);
    private Vector3 yOffset = new Vector3(0, -0.15f, 0);

    [ContextMenu(nameof(CreateKeyboard))]
    public void CreateKeyboard()
    {
        print("Creating Keyboard");
        currentCharacter = 0;
        while (currentCharacter < characters.Length)
        {
            Debug.Log(currentCharacter);
            // Instantiate a button object at the current position with this being the parent
            GameObject button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            button.transform.localPosition = currentPosition;
            button.transform.localRotation = Quaternion.identity;

            // Set the scale of the button object to 2
            button.transform.localScale = new Vector3(2, 2, 2);

            // Set the text of the button to the current character
            //button.GetComponentInChildren<TextMeshProUGUI>().text = characters[currentCharacter];
            button.name = characters[currentCharacter];

            // Set the event of the button
            //button.GetComponent<ButtonScript>().pressEvent.AddListener(() => NameInput.Instance.AddCharacter(characters[currentCharacter]));

            // Move the current position to the next position
            // Check if the current character is at the end of a row of ten
            if (currentCharacter % 10 == 9)
            {
                // If so, move the current position to the next row
                currentPosition += yOffset;
                // Move the current position to the leftmost position
                currentPosition -= xOffset * 9;
            }
            else
            {
                // If not, move the current position to the next character
                currentPosition += xOffset;
            }

            // Increment the current character
            currentCharacter++;
        }
    }
}
