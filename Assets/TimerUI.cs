using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public float timeLimit = 60f;    // Time limit in seconds
    public int timeSinceStart = 0;
    public TextMeshProUGUI textMeshPro;
    public bool gameOver = false;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        yield return new WaitForSeconds(1.0f);
        timeSinceStart++;
        if (Time.realtimeSinceStartup < timeLimit)
        {
            StartCoroutine(Tick());
            if(gameOver == false)
                textMeshPro.text = "Time remaining: " + (timeLimit - timeSinceStart);
        }
        else
        {
            // Implement game over or time-up logic here
            Debug.Log("Time's up!");

            // Update the timer text
            textMeshPro.text = "You win!";
        }
    }

    public void LoseGame()
    {
        timeSinceStart = (int)timeLimit;
        textMeshPro.text = "You lose!";
        gameOver = true;
    }
}