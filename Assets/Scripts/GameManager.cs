using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
private int totalScores;

void Awake(){
    DontDestroyOnLoad(this.gameObject);
}


public void storeScores(int scores){
    totalScores = scores;
}

public int getScores(){
    return totalScores;
}



}
