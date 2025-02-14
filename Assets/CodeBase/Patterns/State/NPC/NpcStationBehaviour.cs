using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Patterns.State.NPC
{
    public class NpcStationBehaviour : MonoBehaviour,IStateSwitcher
    {
        public FirstPersonController _player;

        public BaseNpcState _currentState;
        private List<BaseNpcState> _states;
        public Animator _animator;
        public Image _stateImage;
        private void Start()
        {
            Invoke("InitializeStates",2f);
        }

        private void InitializeStates()
        {
            
            _player = FindObjectOfType<FirstPersonController>();
            _states = new List<BaseNpcState>()
            {
                new FriendlyState(_player,this,_animator,_stateImage),
                new AgressiveState(_player,this,_animator,_stateImage),
                new TalkingState(_player,this,_animator,_stateImage)
            };
            _currentState = _states[0];
            _currentState.StartState();
        }

        public void SwitchState<T>() where T : BaseNpcState
        {
            var state = _states.FirstOrDefault(s => s is T);
            _currentState.ExitState();
            state.StartState();
            _currentState = state;
        }
    }
}