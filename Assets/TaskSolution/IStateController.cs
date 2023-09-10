using AxGrid.FSM;

namespace TaskSolution
{
    public interface IStateController
    {
        public void Enter(FSMState state);
    }
}