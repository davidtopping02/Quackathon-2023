using TMPro;
using UnityEngine;

public class TimeManger : MonoBehaviour
{
    public TextMeshProUGUI m_TextMeshPro;
    [SerializeField]
    public uint m_UpHours = 6;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = m_UpHours;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime / 1.0f; // Subtract one minute in real time

        if (timeLeft <= (0.1 * m_UpHours))
        {
            // penalise the player
            PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseStreangth, 5);
            GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
            args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseSocial, 5);
            GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
            args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseFood, 5);
            GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);

            // Invoke the event with a string parameter
            State endstate = new EndOfDayState();
            GameController.Instance.changeState.Invoke(endstate);
        }

        // Update the timer text
        int hours = Mathf.FloorToInt(timeLeft);
        int minutes = Mathf.FloorToInt((timeLeft - hours) * 60.0f);
        string formattedTime = string.Format("{0:00}:{1:00}", hours, minutes);
        m_TextMeshPro.text = "Time Left: " + formattedTime;
    }
}
