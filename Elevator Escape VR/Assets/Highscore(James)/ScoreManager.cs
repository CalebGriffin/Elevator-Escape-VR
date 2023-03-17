using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private string url = "https://getpantry.cloud/apiv1/pantry/55c7d78d-cf78-44eb-b4c8-b26590c19e12/basket/EEVR";

    void Start() 
    {
        // Get the save data from the internet
        StartCoroutine(GetScores(url));
    }
   
   public IEnumerable<Score> GetHighScores()
   {
        return GVar.Instance.ScoreData.scores.OrderByDescending(x => x.score);
   }

//*
//old code
   public void AddScore(Score score) //a
   {
        // Add score param passed in to the Gvar score data list
        GVar.Instance.ScoreData.scores.Add(score);
   }

    //private void OnDestroy() {
      //SaveScore();  
   // }
//*
    IEnumerator GetScores(string url) //Get the score
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length -1;

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Web request error occurred");
                yield break;
            }
            string textToParse = webRequest.downloadHandler.text;
            GVar.Instance.ScoreData = JsonUtility.FromJson<ScoreData>(textToParse);
        }
         
        // Get the score data class
        // Convert that to json
        
         // Get the score data class
        // Convert that to json
        // Create upload and download buffers
        // Send the request to upload
        // Enjoy some cake 
    }

    public IEnumerator SaveScores(string url) //set the score
    {
        
        string json = JsonUtility.ToJson(GVar.Instance.ScoreData);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, json);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        var jsonBytes = Encoding.UTF8.GetBytes(json);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Web request error occurred");
            yield break;
        }
    }


   
}
