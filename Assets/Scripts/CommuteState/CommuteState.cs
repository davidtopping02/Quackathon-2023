using UnityEngine;
using UnityEngine.SceneManagement;

public class CommuteState : BaseState
{
    public CommuteState() : base()
    {
        Debug.Log("In CommuteState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("CommuteScene");

    }

}