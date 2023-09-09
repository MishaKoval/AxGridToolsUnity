using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Home")]
    public class HomeState : FSMState
    {
        private readonly List<IStateController> stateControllers;
        
        public HomeState(List<IStateController> stateControllers)
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
            Debug.Log("Enter" + nameof(HomeState));
        }

        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(HomeState));
        }
    }
}