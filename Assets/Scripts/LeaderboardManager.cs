using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [Header("Submit Score")]
    private GameManager gameData;
    [SerializeField] TMP_InputField username;
    [SerializeField] private TextMeshProUGUI scoreIndicator;
    [SerializeField] private Button submitButton; // Reference to the button


    [SerializeField] private Transform leaderboardParent;

    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    [SerializeField] private List<TextMeshProUGUI> rank;



    void Start()
    {

        gameData = GameObject.FindObjectOfType<GameManager>();
        loadLeaderboard();
        
        scoreIndicator.text = "Your Score: " + gameData.getScores().ToString();
     
    }

    public async void OnSubmitPressed()
    {
        gameData = GameObject.FindObjectOfType<GameManager>();

        (bool success, string data) = await MySQLManager.SubmitUser(username.text, gameData.getScores().ToString());

        if (success)
        {
            print("Successfully Registered" + data);
            loadLeaderboard();
            submitButton.interactable = false;
        }

        else
        {
            print("Failed to Register");
        }
        username.text = "";
    }

    public async void loadLeaderboard()
    {
        (bool success, string data) = await MySQLManager.LeaderboardData();

        if (success)
        {
      
            string[] rows = data.Split(new[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= rows.Length-1; i++)
            {
                string[] cols = rows[i].Split('#');
                names[i].text = cols[0];
                scores[i].text = cols[1];
                rank[i].text = (i + 1).ToString();
                Debug.Log(cols[0] + " " + cols[1]);
                
            }
        }
        else
        {
            print("Failed to Load");
        }
    }




}
