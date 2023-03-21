using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUi : MonoBehaviour
{
    public GameObject rowUi;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        //scoreManager.AddScore(new Score("eran", 6));
        //scoreManager.AddScore(new Score("elbaz", 66));

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupScoreUi()
    {
        var scores = scoreManager.GetHighScores().ToArray();
        if (scores == null) return;
        for (int i = 0; i < scores.Length; i++)
        {
            GameObject row = GameObject.Instantiate(rowUi, this.gameObject.GetComponent<RectTransform>());
            var rowScript = row.GetComponent<RowUi>();
            rowScript.Rank.text = (i + 1).ToString();
            rowScript.Name.text = scores[i].name;
            rowScript.Score.text = scores[i].score.ToString();
        }
    }
}
