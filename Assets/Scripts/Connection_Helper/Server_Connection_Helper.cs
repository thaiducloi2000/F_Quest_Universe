using System;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

public class Server_Connection_Helper : MonoBehaviour 
{
    private const string BASE_URL = "http://www.mobilebasecashflowapi.somee.com/api/";

    public IEnumerator Post(string endpoint, WWWForm form, Action<UnityWebRequest,float> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(BASE_URL + endpoint, form))
        {
            yield return request.SendWebRequest();
            callback(request,request.downloadProgress);
        }
    }

    public IEnumerator Get(string endpoint, Action<UnityWebRequest,float> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(BASE_URL + endpoint))
        {
            yield return request.SendWebRequest();
            callback(request,request.downloadProgress);
        }
    }

}

