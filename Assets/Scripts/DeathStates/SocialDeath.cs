using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SocialDeath : BaseState
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("death by lack of social");
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("socialDeath");
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        // Code to execute after 2 seconds
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
