using System.Collections;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Path;
using TaskSolution.States;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace TaskSolution
{
    public class WorkerController : MonoBehaviourExt,IStateController
    {
        [SerializeField] private VolumeProfile volumeProfile;
        [SerializeField] private float moveTime;
        [SerializeField] private Transform homeTransform;
        [SerializeField] private Transform workTransform;
        [SerializeField] private Transform shopTransform;
        [SerializeField] private float waitBloomTime;
        
        private const float defaultBloomValue = 1f;
        private const float changeStateBloomValue = 22f;
        private WaitForSeconds _waitBloom;
        private FSMState currentState;
        private int Score;

        [OnAwake]
        private void OnAwake()
        {
            _waitBloom = new WaitForSeconds(waitBloomTime);
            ChangeBloomValue(defaultBloomValue);
           
        }

        [OnStart(-1)]
        private void OnStart()
        {
            Settings.GlobalModel.Set("Score",Score);
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
                    if (Score > 0)
                    {
                        Score--;
                    }
                    break;
                case WorkState:
                    Score++;
                    break;
            } 
            Settings.GlobalModel.Set("Score",Score);
        }

        public void Enter(FSMState state)
        {
            if (currentState != null)
            {
                if (currentState != state)
                {
                    ChangeBloomValue(changeStateBloomValue);
                    StartCoroutine(WaitBloom());
                }
            }
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
        
        private IEnumerator WaitBloom()
        {
            yield return _waitBloom;
            ChangeBloomValue(defaultBloomValue);
        }
        
        private void ChangeBloomValue(float value)
        {
            if (volumeProfile.TryGet(out Bloom bloom))
            {
                bloom.intensity.value = value;
            }
        }
    }
}