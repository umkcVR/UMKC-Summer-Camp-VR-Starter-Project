using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject chestObject;      // Reference to the chest object
    public int attackThreshold = 3;     // Number of attacks needed to lose the game
    public TimerUI timerUI;
    public int attackCount = 0;            // Current attack count
    public bool gameOver = false;
    public void Attacked()
    {
        attackCount++;
        if (attackCount >= attackThreshold && gameOver == false)
        {
            LoseGame();
        }
    }
    void LoseGame()
    {
        // Disable the chest object to make it disappear
        chestObject.SetActive(false);
        timerUI.LoseGame(); 
        // Add additional lose game logic here
        Debug.Log("You lose the game!");
        gameOver = true;
    }
}





