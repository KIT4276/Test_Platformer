namespace Platformer.States
{
    public class LoadProgressState : IState
    {
        private const string Main = "Main";
        private readonly StateMachine _gameStateMachine;

        public LoadProgressState(StateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter() => 
            _gameStateMachine.Enter<LoadLevelState, string>(Main);

        public void Exit(){}
    }
}