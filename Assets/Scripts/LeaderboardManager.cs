using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [Header("Submit Score")]
    private GameManager gameData;
    [SerializeField] TMP_InputField username;


    [SerializeField] private GameObject rowUi;
    [SerializeField] private Transform leaderboardParent;

    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;



    void Start()
    {
        loadLeaderboard();
    }

    public async void OnSubmitPressed()
    {
        gameData = GameObject.FindObjectOfType<GameManager>();

        (bool success, string data) = await MySQLManager.SubmitUser(username.text, gameData.getScores().ToString());

        if (success)
        {
            print("Successfully Registered" + data);
            loadLeaderboard();
        }

        else
        {
            print("Failed to Register");
        }

    }

    public async void loadLeaderboard()
    {
        (bool success, string data) = await MySQLManager.LeaderboardData();

        if (success)
        {
            print("Successfully Loaded" + data);
            string[] rows = data.Split('\n');

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split('#');
                names[i].text = cols[0];
                scores[i].text = cols[1];
            }
        }
        else
        {
            print("Failed to Load");
        }
    }

    void generateRows(string data)
    {
        string[] rows = data.Split('\n');
        for (int i = 0; i < rows.Length; i++)
        {
            string[] cols = rows[i].Split('#');
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();

            row.username.text = cols[0];
            row.score.text = cols[1];
        }
    }


}
