using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Home")]
    public class HomeState : FSMState
    {
        [Enter]
        private void EnterState()
        {
            Debug.Log("Enter" + nameof(HomeState));
        }

        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(HomeState));
        }
    }
}