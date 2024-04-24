using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class MySQLManager
{
    readonly static string SERVER_URL = "http://localhost:80/UnityGame";

//This function will submit the user data to the database
public static async Task<(bool success, string returnMessage)> SubmitUser(string username, string score)
{
  
    //The url to add the data
    string ADD_USER_URL = $"{SERVER_URL}/addUsers.php";
    //Send the data to the server
    return await SendPostRequest(ADD_USER_URL, new Dictionary<string, string>
    {
        {"username", username},
        {"score", score}
    });
}

//This function will get the leaderboard data from the database
public static async Task<(bool success, string returnMessage)>LeaderboardData()
{
  
    //The url to get the data
    string GET_DATA = $"{SERVER_URL}/viewTable.php";
    //Send the data to the server
    return await SendPostRequest(GET_DATA, new Dictionary<string, string>
    { 
       
    } );
}


//This function will send a post request to the server
static async Task<(bool success, string returnMessage)>SendPostRequest(string url, Dictionary<string, string> data){
    //Create a new form
    using(UnityWebRequest req = UnityWebRequest.Post(url, data)){
        //Send the request
        req.SendWebRequest();
        //Wait for the request to finish
        while(!req.isDone) await Task.Delay(100);
            
        //When task is done
        if(req.error != null 
        || !string.IsNullOrWhiteSpace(req.error) 
        || HasErrorMessage(req.downloadHandler.text))
        return (false, req.downloadHandler.text);
            
        //On Success
        return (true, req.downloadHandler.text);
    }

}

//This function will check if the message is an error message
static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

}


