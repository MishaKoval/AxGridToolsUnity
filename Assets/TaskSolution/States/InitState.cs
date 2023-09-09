using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Init")]
    public class InitState : FSMState
    {
        [Enter]
        private void EnterState()
        {
            Debug.Log("Enter" + nameof(InitState));
        }

        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(InitState));
        }
    }
}