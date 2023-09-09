using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Work")]
    public class WorkState : FSMState
    {
        private readonly List<IStateController> stateControllers;
        
        public WorkState(List<IStateController> stateControllers)
        {
            this.stateControllers = stateControllers;
        }
        
        [Enter]
        private void EnterState()
        {
            foreach (var stateController in stateControllers)
            {
                stateController.Enter(this);
            }
            Debug.Log("Enter" + nameof(WorkState));
        }
        
        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(WorkState));
        }
    }
}