using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Patterns.State.PlayerState
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public enum PlayerBehaviourStates
        {
            Agressive,
            Friendly,
            Talker
        }
       public PlayerBehaviourStates currentBehaviourState;

       private void Start()
       {
           currentBehaviourState = PlayerBehaviourStates.Friendly;
       }
    }
}