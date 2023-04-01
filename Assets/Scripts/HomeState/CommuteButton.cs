using UnityEngine;
using UnityEngine.UI;

public class CommuteButton : MonoBehaviour
{
    public void AddButtonListener()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(buttonClickHandler);
    }

    // invoke the change state evenet
    private void buttonClickHandler()
    {
        // Define the event type with a string parameter

        // Invoke the event with a string parameter
        State commuteState = new CommuteState();
        GameController.Instance.changeState.Invoke(commuteState);
        Debug.Log("clicked");
    }

    void Start()
    {
        AddButtonListener();
    }
}
