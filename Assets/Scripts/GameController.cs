using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    public bool isDebug = false;
    public GameObject timeInDay;

    // state machine fields
    public static GameController Instance { get; private set; }
    public UnityEvent<State> changeState = new UnityEvent<State>();

    private State currentState;

    // Initialize and persist GameManager script across scenes.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        Instantiate(player, transform.position, transform.rotation, this.transform);
        Instantiate(timeInDay, transform.position, transform.rotation, this.transform);
        changeState.AddListener(HandeStateChange);

        // initialises the current state to the home state on start-up
        if (isDebug)
        {
            return;
        }
        currentState = new HomeState();

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
            currentState = newState;
            currentState.OnEnter();
        }
    }

}
