using System.Threading;
using System.Timers;
using UnityEngine;

public static class ScoreManager
{
    private static int currentScore = 0;
    private static int bestScore = -1;
    private static bool terminateCount = false;


    public static void StartScore()
    {
        Thread thread = new Thread(IncrementScore);
        thread.Start();
    }

    public static void finishScore()
    {
        terminateCount = true;
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
        }

        currentScore = 0;
    }

    public static int CurrentScore()
    {
        return currentScore;
    }

    public static int BestScore()
    {
        return bestScore;
    }

    static void  IncrementScore()
    {
        while (!terminateCount)
        {
            Thread.Sleep(5000);
            currentScore++;
            Debug.Log(currentScore);
        }
    }
}