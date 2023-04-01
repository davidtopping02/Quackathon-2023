using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    private State currentState;

    // Initialize and persist GameManager script across scenes.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //initialise the player object

        // initialises the current state to the home state on start-up
        // pass player into home state
        currentState = new HomeState();
        currentState.OnEnter();
    }

    void Update()
    {
        // On update, call the OnUpdate method of the current state. 
        HandleNewState(currentState.OnUpdate(), currentState);
    }


    // updates the current state if the new state is different from the old state, and calls the OnEnter method of the current state to perform any initialization required by the new state.
    void HandleNewState(State newState, State oldState)
    {
        if (newState != oldState)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }

}
