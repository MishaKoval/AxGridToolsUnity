using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Shop")]
    public class ShopState : FSMState
    {
        private readonly List<IStateController> stateControllers;
        
        public ShopState(List<IStateController> stateControllers)
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
            Debug.Log("Enter" + nameof(ShopState));
        }

        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(ShopState));
        }
    }
}