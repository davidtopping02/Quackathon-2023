using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameController : MonoBehaviour
{
    public GameObject bug;

    public TextMeshProUGUI ScoreBoard;

    public GameObject summaryScreen;

    public TextMeshProUGUI moneySummary;

    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fired");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
                score++;
                ScoreBoard.text = score.ToString();
            }
        }

        
    }

    private void Start()
    {
        
        StartCoroutine(spawnBug());
    }

    private IEnumerator spawnBug()
    {
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 randomPos = new Vector3(Random.Range(-10, 10), Random.Range(-6, 6), 1);
            GameObject newBug = Instantiate(bug);
            newBug.transform.position = randomPos;
        }

    }

    public void setSummaryActive()
    {
        summaryScreen.SetActive(true);
        moneySummary.text = score.ToString();
        
    }

   


}
