using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class BarGameController : MonoBehaviour
{

    public GameObject target;

    public TextMeshProUGUI ScoreBoard;

    public GameObject summaryScreen;

    public TextMeshProUGUI scoreSummary;
    public TextMeshProUGUI bullseyeSummary;

    private int score = 0;
    private int bullseyes = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                //Destroy(hit.transform.gameObject);
                //spawnNewTarget();
                if(hit.transform.gameObject.name == "Bullseye")
                {
                    score += 2;
                    bullseyes++;
                }
                score++;
                ScoreBoard.text = score.ToString();
            }
        }
    }

    /*void spawnNewTarget()
    {
        Vector3 randomPos = new Vector3(Random.Range(-10,8), Random.Range(-6, 6), 1);
        Debug.Log(randomPos);
        GameObject newTarget = Instantiate(target);
        newTarget.transform.position = randomPos;
    }*/


    public void setSummaryActive()
    {
        summaryScreen.SetActive(true);
        scoreSummary.text = "Score = " + score.ToString();
        bullseyeSummary.text = "Bullseyes = " + bullseyes.ToString();

        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseSocial, score);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);


    }
}
