using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class SimpleTweener : MonoBehaviour
    {
        private List<ITweenOperation> _tweenOperations = new();

        public void Run(ITweenOperation operation)
        {
            operation.Complete += OnOperationComplete;
            _tweenOperations.Add(operation);
        }

        private void OnOperationComplete(ITweenOperation operation)
        {
            operation.Complete -= OnOperationComplete;
        }
    }
}
