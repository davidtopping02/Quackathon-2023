public interface State
{

    // On Enter should implement any one-off logic that needs to happen when the state is entered.
    void OnEnter();

    // On Update should implement any logic that needs to happen every frame.
    State OnUpdate();

}