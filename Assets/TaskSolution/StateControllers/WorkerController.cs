using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Path;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution.StateControllers
{
    public class WorkerController : MonoBehaviourExt,IStateController
    {
        [SerializeField] private float moveTime;
        [SerializeField] private Transform homeTransform;
        [SerializeField] private Transform workTransform;
        [SerializeField] private Transform shopTransform;
        private FSMState currentState;
        private int score;
        
        [OnStart(-1)]
        private void OnStart()
        {
            Settings.GlobalModel.Set("Score",score);
        }

        [OnUpdate]
        private void ChangeMoney()
        {
            switch (currentState)
            {
                case null:
                    return;
                case HomeState:
                    break;
                case ShopState:
                    if (score > 0)
                    {
                        score--;
                    }
                    break;
                case WorkState:
                    score++;
                    break;
            } 
            Settings.GlobalModel.Set("Score",score);
        }

        public void Enter(FSMState state)
        {
            currentState = state;
            Path = null;
            if (state is HomeState)
            {
                GoToHome();
            }
            if (state is ShopState)
            {
                GoToShop();
            }
            if (state is WorkState)
            {
                GoToWork();
            }
        }
        
        [ContextMenu("Shop")]
        private void GoToShop()
        {
            Path = new CPath().EasingLinear(moveTime, 0, 1,
                (f) => transform.position = Vector3.Lerp(transform.position, shopTransform.position, f));
        }
        
        [ContextMenu("Work")]
        private void GoToWork()
        {
            Path = new CPath().EasingLinear(moveTime, 0, 1,
                (f) => transform.position = Vector3.Lerp(transform.position, workTransform.position, f));
        }
        
        [ContextMenu("Home")]
        private void GoToHome()
        {
            Path = new CPath().EasingLinear(moveTime, 0, 1,
                (f) => transform.position = Vector3.Lerp(transform.position, homeTransform.position, f));
        }
    }
}