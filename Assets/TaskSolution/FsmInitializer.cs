using System.Collections.Generic;
using AxGrid.Base;
using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution
{
    public class FsmInitializer : MonoBehaviourExtBind
    {
        [SerializeField] private WorkerController workerController;
        
        [OnStart]
        private void StartThis()
        {
            Log.Debug("InitFsm");
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new HomeState(new List<IStateController>(){workerController}));
            Settings.Fsm.Add(new WorkState(new List<IStateController>(){workerController}));
            Settings.Fsm.Add(new ShopState(new List<IStateController>(){workerController}));
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