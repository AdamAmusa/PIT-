using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
using System.Collections.Concurrent;

public partial class HighScore : RealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId? Id { get; set; }

    [MapTo("score")]
    public int? Score { get; set; }

    [MapTo("time-survived")]
    public double? TimeSurvived { get; set; }

    [MapTo("username")]
    public string Username { get; set; }

    public HighScore()
    {
        Id = ObjectId.GenerateNewId();
    }
}
