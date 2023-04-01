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

        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseMoney, score);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);


    }

}
