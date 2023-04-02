using UnityEngine;
using UnityEngine.SceneManagement;

public class StrengthDeath : BaseState
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("death by lack of strength");


    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("strengthDeath");
    }

}
