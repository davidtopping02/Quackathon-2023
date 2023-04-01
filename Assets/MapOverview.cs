using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MapOverview : MonoBehaviour
{
    public GameObject goToWork;

    // Start is called before the first frame update


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.name == "shop")
            {
                shop();
            }
            else if(hit.collider.name == "work")
            {
                work();
            }
            else if (hit.collider.name == "gym")
            {
                gym();
            }
            else if (hit.collider.name == "house")
            {
                house();
            }
            else if (hit.collider.name == "bar")
            {
                bar();
            }
            else
            {

            }

        }


    }
    public void work()
    {
        goToWork.SetActive(true);

    }

    public void shop()
    {
        State shopState = new ShopState();
        GameController.Instance.changeState.Invoke(shopState);
       
        
    }

    public void bar()
    {
        State barState = new BarState();
        GameController.Instance.changeState.Invoke(barState);
        
    }

    public void gym()
    {
        State gymState = new GymState();
        GameController.Instance.changeState.Invoke(gymState);
    }

    public void house()
    {
        State houseState = new HouseState();
        GameController.Instance.changeState.Invoke(houseState);

    }

}
