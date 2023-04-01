using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDayState : BaseState
{
    public EndOfDayState() : base()
    {
        Debug.Log("In end of day state");
    }


    void Start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("EndOfDayScene");
        changeScene();
    }



    IEnumerator changeScene()
    {
        // Code to execute after 2 seconds
        yield return new WaitForSeconds(5f);
        State homeState = new HomeState();
        GameController.Instance.changeState.Invoke(homeState);
    }
}