using AxGrid.FSM;
using UnityEngine;

namespace TaskSolution.States
{
    [State("Shop")]
    public class ShopState : FSMState
    {
        [Enter]
        private void EnterState()
        {
            Debug.Log("Enter" + nameof(ShopState));
        }

        [Exit]
        private void ExitState()
        {
            Debug.Log("Exit" + nameof(ShopState));
        }
    }
}