using UnityEngine;
using UnityEngine.UI;

public class TravelButton : MonoBehaviour
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
        State travelState = new TravelState();
        GameController.Instance.changeState.Invoke(travelState);
        Debug.Log("clicked");
    }

    void Start()
    {
        AddButtonListener();
    }
}
