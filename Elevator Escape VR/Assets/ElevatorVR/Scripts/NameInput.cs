using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{
    public static NameInput Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private TextMeshProUGUI nameText;

    private string[] characters = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    bool inputEnabled = true;
    bool firstButton = true;
    bool isCaps = false;
    string playerName = "";

    // Start is called before the first frame update
    void Start()
    {
        DefaultName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateNameText()
    {
        nameText.text = playerName;
    }

    private void DefaultName()
    {
        playerName = "Player";
        for (int i = 0; i < 5; i++)
            playerName += Random.Range(0, characters.Length);
    }

    public void AddCharacter(string character)
    {
        if (!inputEnabled)
            return;

        if (firstButton)
        {
            playerName = "";
            firstButton = false;
        }

        playerName += isCaps ? character.ToUpper() : character.ToLower();
    }

    public void Backspace()
    {
        if (!inputEnabled)
            return;

        playerName = playerName.Substring(0, playerName.Length - 1);
    }

    public void Caps()
    {
        isCaps = !isCaps;
    }

    public void Clear()
    {
        if (!inputEnabled)
            return;

        playerName = "";
        UpdateNameText();
        DefaultName();
        firstButton = true;
    }

    public void Enter()
    {
        if (!inputEnabled)
            return;

        GVar.Instance.PlayerName = playerName;
        inputEnabled = false;
    }
}
