using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubmissionManager : MonoBehaviour
{
   [Header("Submit Score")]
   private EnemySpawner gameData;
   [SerializeField] TMP_InputField username;


    public async void OnSubmitPressed()
    {
     if(await MySQLManager.SubmitUser(username.text, "200")){
        print("Successfully Registered");
     }
     else{
         print("Failed to Register");
     }
    }

}
