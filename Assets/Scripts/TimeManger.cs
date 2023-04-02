using TMPro;
using UnityEngine;

public class TimeManger : MonoBehaviour
{
    public TextMeshProUGUI m_TextMeshPro;
    [SerializeField]
    public uint m_UpHours = 9;
    float timeLeft;

    bool hasEnded = false;

    // Start is called before the first frame update
    void Awake()
    {
        timeLeft = m_UpHours;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime / 60.0f; // Subtract one minute in real time

        if (timeLeft <= 0)
        {

            if(hasEnded)
            {
                Destroy(gameObject);
                return; 
            }

            hasEnded = true;
            // penalise the player
            PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseStreangth, 5);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);
            args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseSocial, 5);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);
            args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseFood, 5);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);

            // Invoke the event with a string parameter
            State endstate = new EndOfDayState();
            GameController.Instance.changeState.Invoke(endstate);
        }

        // Update the timer text
        int hours = Mathf.FloorToInt(timeLeft);
        int minutes = Mathf.FloorToInt((timeLeft - hours) * 60.0f);
        string formattedTime = string.Format("{0:00}:{1:00}", hours, minutes);
        m_TextMeshPro.text = "Time Left: " + formattedTime;
        m_TextMeshPro.fontSize = 20;
    }

    public void resetTimer()
    {
        timeLeft = m_UpHours;
    }
}
