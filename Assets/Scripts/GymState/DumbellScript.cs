using UnityEngine;
using UnityEngine.UI;

public class DumbellScript : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

    }

    void OnClick()
    {
        GameController.Instance.player.StatsChangeEvent.Invoke(new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseStreangth, 1));
    }


}
