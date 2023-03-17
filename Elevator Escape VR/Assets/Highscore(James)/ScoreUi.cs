using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager.AddScore(new Score("eran", 6));
        scoreManager.AddScore(new Score("elbaz", 66));

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i <scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.Rank.text = (i + 1).ToString();
            row.Name.text = scores[i].name;
            row.Score.text = scores[i].score.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
