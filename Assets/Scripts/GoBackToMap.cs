using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMap : MonoBehaviour
{
    public void BackToMap()
    {
        //State travelState = new com();
        GameController.Instance.changeState.Invoke(travelState);
    }
}