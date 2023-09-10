using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Path;
using TaskSolution.States;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace TaskSolution.StateControllers
{
    public class BloomChangeController : MonoBehaviourExt,IStateController
    {
        [SerializeField] private float waitBloomTime;
        [SerializeField] private VolumeProfile volumeProfile;
        private const float DefaultBloomValue = 1f;
        private const float ChangeStateBloomValue = 22f;
        
        private FSMState currentState;
        
        public void Enter(FSMState state)
        {
            if (currentState != null)
            {
                if (currentState != state)
                {
                    ChangeBloom();
                }
            }
            currentState = state;
        }
        
        [OnAwake]
        private void OnAwake()
        {
            ChangeBloomValue(DefaultBloomValue);
        }

        private void ChangeBloom()
        {
            ChangeBloomValue(DefaultBloomValue);
            Path = new CPath().EasingLinear(waitBloomTime, DefaultBloomValue, ChangeStateBloomValue, (f) =>
            {
                if (volumeProfile.TryGet(out Bloom bloom))
                {
                    bloom.intensity.value = f;
                }
            }).Action(()=> ChangeBloomValue(DefaultBloomValue));
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