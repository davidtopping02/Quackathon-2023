using System.Collections;
using System.Collections.Generic;
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
        timeLeft -= Time.deltaTime / 60.0f; // Subtract one minute in real time

        if (timeLeft <= (0.1 * m_UpHours))
        {
            // Ha ha I am in danger... 
        }

        // Update the timer text
        int hours = Mathf.FloorToInt(timeLeft);
        int minutes = Mathf.FloorToInt((timeLeft - hours) * 60.0f);
        string formattedTime = string.Format("{0:00}:{1:00}", hours, minutes);
        m_TextMeshPro.text = "Time Left: " + formattedTime;
    }
}
