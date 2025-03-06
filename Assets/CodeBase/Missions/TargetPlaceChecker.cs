using System;
using UnityEngine;

namespace CodeBase.Missions
{
    public class TargetPlaceChecker : MonoBehaviour
    {
        private bool _isPlayerOnPlace;
        
        public bool CheckPlayerPresenting()
        {
            return _isPlayerOnPlace;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayerOnPlace = true;
            }
        }
    }
}