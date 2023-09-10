using AxGrid.Base;
using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using TaskSolution.StateControllers;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution
{
    public class FsmInitializer : MonoBehaviourExtBind
    {
        [SerializeField] private StateControllersInitializer stateControllersInitializer;
        
        [OnStart]
        private void StartThis()
        {
            Log.Debug("InitFsm");
            var stateControllers = stateControllersInitializer.GetStateControllers();
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new HomeState(stateControllers));
            Settings.Fsm.Add(new WorkState(stateControllers));
            Settings.Fsm.Add(new ShopState(stateControllers));
            Settings.Fsm.Start("Init");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
        
        [Bind("OnHomeClick")]
        private void BindEventOne()
        {
            Settings.Fsm.Change("Home");
            Log.Debug($"HomeClick");
        }
        
        [Bind("OnShopClick")]
        private void BindEventTwo()
        {
            Settings.Fsm.Change("Shop");
            Log.Debug($"ShopClick");
        }
        
        [Bind("OnWorkClick")]
        private void BindEventThree()
        {
            Settings.Fsm.Change("Work");
            Log.Debug($"WorkClick");
        }
    }
}