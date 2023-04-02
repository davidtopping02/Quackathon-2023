using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public bool isDebug = false;
    public GameObject timeInDay = null;

    // state machine fields

    private static GameController instance = null; 
    public static GameController Instance { get {
            if(instance == null)
            {
                instance = FindObjectOfType<GameController>();
            }
            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "GameController";
                instance = gObj.AddComponent<GameController>();
                DontDestroyOnLoad(gObj);
            }
            return instance;
        } 
    }
    public UnityEvent<State> changeState = new UnityEvent<State>();
    public PlayerStats player = new PlayerStats();

    private State currentState;

    // Initialize and persist GameManager script across scenes.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = new PlayerStats();
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
        //Instantiate(player, transform.position, transform.rotation, this.transform);
        changeState.AddListener(HandeStateChange);

        // initialises the current state to the home state on start-up
        if (isDebug)
        {
            return;
        }
        currentState = new MainMenuState();

        currentState.OnEnter();
    }

    private void HandeStateChange(State stateChange)
    {
        HandleNewState(stateChange, currentState);
    }

    void Update()
    {
        if (isDebug)
        {
            return;
        }
        // On update, call the OnUpdate method of the current state. 
        currentState.OnUpdate();
    }


    // updates the current state if the new state is different from the old state, and calls the OnEnter method of the current state to perform any initialization required by the new state.
    void HandleNewState(State newState, State oldState)
    {
        if (newState != oldState)
        {
            if (newState.GetType().Name == "HomeState" )
            {
                if(!timeInDay.scene.IsValid())
                    Instantiate(timeInDay, transform.position, transform.rotation, this.transform);
                else
                {
                    // timer reset
                    timeInDay.GetComponent<TimeManger>().resetTimer();
                }
              
            }
            currentState = newState;
            currentState.OnEnter();
        }
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
