using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class MySQLManager
{
    readonly static string SERVER_URL = "http://localhost:80/UnityGame";

public static async Task<bool> SubmitUser(string username, string score)
{
  
    string REGISTER_USER_URL = $"{SERVER_URL}/addUsers.php";
    return await SendPostRequest(REGISTER_USER_URL, new Dictionary<string, string>
    {
        {"username", username},
        {"score", score}
    });
}

static async Task<bool>SendPostRequest(string url, Dictionary<string, string> data){
    using(UnityWebRequest req = UnityWebRequest.Post(url, data)){
        req.SendWebRequest();

        while(!req.isDone) await Task.Delay(100);
            
        //When rask is done
        if(req.error != null 
        || !string.IsNullOrWhiteSpace(req.error) 
        || HasErrorMessage(req.downloadHandler.text))
        return false;
            
        //On Success
        return true;
    }

}

static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

}
public class Data{
    public string username;
    public int score;    
}


