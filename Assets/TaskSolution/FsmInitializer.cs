using AxGrid.Base;
using AxGrid;
using AxGrid.FSM;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution
{
    public class FsmInitializer : MonoBehaviourExtBind
    {
        [OnStart]
        private void StartThis()
        {
            Debug.Log("InitFsm");
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new HomeState());
            Settings.Fsm.Add(new WorkState());
            Settings.Fsm.Add(new ShopState());
            Settings.Fsm.Start("Init");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}