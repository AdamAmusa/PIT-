using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class MySQLManager
{
    readonly static string SERVER_URL = "http://localhost:80/UnityGame";

public static async Task<(bool success, string returnMessage)> SubmitUser(string username, string score)
{
  
    string ADD_USER_URL = $"{SERVER_URL}/addUsers.php";
    return await SendPostRequest(ADD_USER_URL, new Dictionary<string, string>
    {
        {"username", username},
        {"score", score}
    });
}

public static async Task<(bool success, string returnMessage)>LeaderboardData()
{
  
    string GET_DATA = $"{SERVER_URL}/viewTable.php";
    return await SendPostRequest(GET_DATA, new Dictionary<string, string>
    { 
       
    } );
}

static async Task<(bool success, string returnMessage)>SendPostRequest(string url, Dictionary<string, string> data){
    using(UnityWebRequest req = UnityWebRequest.Post(url, data)){
        req.SendWebRequest();

        while(!req.isDone) await Task.Delay(100);
            
        //When rask is done
        if(req.error != null 
        || !string.IsNullOrWhiteSpace(req.error) 
        || HasErrorMessage(req.downloadHandler.text))
        return (false, req.downloadHandler.text);
            
        //On Success
        return (true, req.downloadHandler.text);
    }

}

static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

}


