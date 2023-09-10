using System;
using AxGrid.Base;
using AxGrid.FSM;
using TaskSolution.States;
using UnityEngine;
using UnityEngine.UI;

namespace TaskSolution.StateControllers
{
    public class ButtonsStateController : MonoBehaviourExt , IStateController
    {
        [SerializeField] private Button homeBtn;
        [SerializeField] private Button shopBtn;
        [SerializeField] private Button workBtn;
        
        public void Enter(FSMState state)
        {
            EnableAllButtons();
            switch (state)
            {
                case HomeState:
                    homeBtn.interactable = false;
                    break;
                case ShopState:
                    shopBtn.interactable = false;
                    break;
                case WorkState:
                    workBtn.interactable = false;
                    break;
                default:
                    throw new ArgumentException("UnknownState!");
            }
        }

        private void EnableAllButtons()
        {
            homeBtn.interactable = true;
            shopBtn.interactable = true;
            workBtn.interactable = true;
        }
    }
}