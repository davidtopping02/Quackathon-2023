using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounter : MonoBehaviour
{

    public TextMeshProUGUI daysCounterText;
    // Start is called before the first frame update
    void Start()
    {
        daysCounterText.text = "Days Survived " + GameController.Instance.player.DaysSurvived.ToString();
    }

   
}
