using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionManager : MonoBehaviour
{
   [Header("Submit Score")]
   private EnemySpawner gameData;
   [SerializeField] string username;


    public async void OnSubmitPressed()
    {
     if(await MySQLManager.SubmitUser(username, gameData.getScore().ToString())){
        print("Successfully Registered");
     }
     else{
         print("Failed to Register");
     }
    }

}
