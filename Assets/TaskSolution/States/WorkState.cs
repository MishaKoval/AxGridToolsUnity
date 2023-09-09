using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Work")]
    public class WorkState : FSMState
    {
        [Enter]
        private void EnterState()
        {
            Debug.Log("Enter" + nameof(WorkState));
        }
        
        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(WorkState));
        }
    }
}