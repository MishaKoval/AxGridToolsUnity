using System;
using AxGrid.Base;
using AxGrid.FSM;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution.StateControllers
{
    public class BackgroundController : MonoBehaviourExt,IStateController
    {
        [SerializeField] private Camera cameraWithBackground;
        
        [SerializeField] private Color32 homeBackgroundColor;
        [SerializeField] private Color32 shopBackgroundColor;
        [SerializeField] private Color32 workBackgroundColor;
        
        public void Enter(FSMState state)
        {
            switch (state)
            {
                case HomeState:
                    cameraWithBackground.backgroundColor = homeBackgroundColor;
                    break;
                case ShopState:
                    cameraWithBackground.backgroundColor = shopBackgroundColor;
                    break;
                case WorkState:
                    cameraWithBackground.backgroundColor = workBackgroundColor;
                    break;
                default:
                    throw new ArgumentException("UnknownState!");
            }
        }
    }
}