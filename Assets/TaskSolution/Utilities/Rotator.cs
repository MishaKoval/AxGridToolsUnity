using AxGrid.Base;
using UnityEngine;

namespace TaskSolution.Utilities
{
    public class Rotator : MonoBehaviourExt
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private Vector3 axis;
        
        [OnUpdate]
        private void OnUpdate()
        {
            transform.Rotate(axis * rotateSpeed);
        }
    }
}