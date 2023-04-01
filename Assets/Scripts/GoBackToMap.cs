using UnityEngine;

public class GoBackToMap : MonoBehaviour
{
    public void BackToMap()
    {
        buttonClickHandler();
    }

    private void buttonClickHandler()
    {
        // Invoke the event with a string parameter
        State commuteState = new CommuteState();
        GameController.Instance.changeState.Invoke(commuteState);
    }

}