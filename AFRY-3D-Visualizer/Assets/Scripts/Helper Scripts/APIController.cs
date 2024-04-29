using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIController : MonoBehaviour
{
    private string url = "https://localhost:7030/api/MacMachines/GetAllMacMachines"; // Replace with your API endpoint

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}