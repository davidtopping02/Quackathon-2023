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
        GameController.Instance.player.GetComponent<PlayerStats>.updateStrength(5);
    }
}
