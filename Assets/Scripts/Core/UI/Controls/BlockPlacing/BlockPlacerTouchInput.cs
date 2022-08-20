using System;
using Core.BlockPlacing;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI.Controls.BlockPlacing
{
    public class BlockPlacerTouchInput : MonoBehaviour, IBlockPlacerInput, IPointerDownHandler
    {
        public event Action Pressed;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed?.Invoke();
        }
    }
}