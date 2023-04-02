using TMPro;
using UnityEngine;

public class GymController : MonoBehaviour
{

    public TextMeshProUGUI ScoreBoard;
    public GameObject summaryScreen;
    public TextMeshProUGUI moneySummary;
    public int score = 0;

    public void onButtonClick()
    {
        score++;
        ScoreBoard.text = score.ToString();
    }



    public void setSummaryActive()
    {
        summaryScreen.SetActive(true);
        moneySummary.text = score.ToString();

        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseStreangth, score);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);

        //Lower food after gym
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseFood, -10);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);


    }

}
