using System.Collections.Generic;
using AxGrid;
using TaskSolution.States;
using UnityEngine;

namespace TaskSolution.StateControllers
{
    public class StateControllersInitializer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> stateControllers;
         
        public List<IStateController> GetStateControllers()
        {
            List<IStateController> result = new();
            foreach (var obj in stateControllers)
            {
                if (obj.TryGetComponent(out IStateController iStateController))
                {
                    result.Add(iStateController);
                }
            }
            Log.Debug(result.Count.ToString());
            return result;
        }
    }
}