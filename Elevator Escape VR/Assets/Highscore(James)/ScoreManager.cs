using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private string urlOLD = "https://getpantry.cloud/apiv1/pantry/55c7d78d-cf78-44eb-b4c8-b26590c19e12/basket/EEVR";
    private const string url = "https://api.jsonbin.io/v3/b/64187542c0e7653a058b4774?meta=false";
    private const string masterKey = "$2b$10$8XZpgl/oBCb6HAE9UiLnb.PfuEGElShOI530PJiWx/i7Pea0uVcVm";

    [SerializeField] private ScoreUi scoreUi;

    void Start() 
    {
        // Get the save data from the internet
        StartCoroutine(GetScores(url));
    }
   
    public IEnumerable<Score> GetHighScores()
    {
        return GVar.Instance.ScoreData.scores.OrderByDescending(s => s.score).Take(7);
    }


    public void AddScore(Score score) //a
    {
        print("adding score: " + score.name);
        // Add score param passed in to the Gvar score data list
        GVar.Instance.ScoreData.scores.Add(score);
    }

    IEnumerator GetScores(string url) //Get the score
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("X-Master-key", masterKey);
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length -1;

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Web request error occurred");
                yield break;
            }
            string textToParse = webRequest.downloadHandler.text;
            print(textToParse);
            GVar.Instance.ScoreData = JsonUtility.FromJson<ScoreData>(textToParse);
        }

        scoreUi.SetupScoreUi();
    }

    public void SaveScores()
    {
        StartCoroutine(SaveScores(url));
    }

    public IEnumerator SaveScores(string url) //set the score
    {
        string json = JsonUtility.ToJson(GVar.Instance.ScoreData);
        print(json);
        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, json))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("X-Master-key", masterKey);
            var jsonBytes = Encoding.UTF8.GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Web request error occurred");
                yield break;
            }
            else
            {
                print("success");
            }
        }
        StartCoroutine(GetScores(url));
    }
}