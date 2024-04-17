using System.Collections;
using System.Collections.Generic;
using Realms;
using Realms.Sync;
using UnityEngine;
using System.Threading.Tasks;
using Realms.Sync.ErrorHandling;
using Realms.Sync.Exceptions;
using System.Linq;

public class RealmController : MonoBehaviour
{
    private Realm realm;
    private readonly string myRealmAppId = "game-jsksw"; // Realm app id

    public RealmController()
    {
        InitAsync();
    }


    public async void InitAsync()
    {
        var app = App.Create(myRealmAppId);
        User user = await Get_userAsync(app);
        PartitionSyncConfiguration config = GetConfig(user);
        realm = await Realm.GetInstanceAsync(config);
    }



    private async Task<User> Get_userAsync(App app)
    {
        User user = app.CurrentUser;
        if (user == null)
        {
            user = await app.LogInAsync(Credentials.Anonymous());
        }
        return user;
    }




    private PartitionSyncConfiguration GetConfig(User user)
    {
        PartitionSyncConfiguration config = new("Game", user);

        config.ClientResetHandler = new DiscardLocalResetHandler()
        {
            ManualResetFallback = (ClientResetException ex) => ex.InitiateClientReset()
        };
        return config;
    }


    //Call when game is over to add highscore
    //Username is entered by the player
    public void AddHighScore(string username, int score)
    {
        if (realm == null)
        {
            Debug.Log("Realm is not initialized");
            return;
        }
        var currentHighScore = realm.All<HighScore>().Where(highscore => highscore.Username == username).FirstOrDefault();

        realm.Write(() =>
        {
            if (currentHighScore == null)
            {
                realm.Add(new HighScore
                {
                    Username = username,
                    Score = score
                });
            }
            else
            {
                if (currentHighScore.Score < score)
                {
                    currentHighScore.Score = score;
                }
            }
        });

    }
}
