using System.Collections.Generic;
using System.Linq;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.Patterns.State.NPC
{
    public class NpcStationBehaviour : MonoBehaviour,IStateSwitcher,IInteractable
    {
        public Movement _player;
        public BaseNpcState _currentState;
        public Animator _animator;
        public Image _stateImage;
        private List<BaseNpcState> _states;

        private void OnEnable()
        {
            
           EventBus.EventBus.Instance.onSceneLoaded += InitializeStates;
        }
        private void OnDisable()
        {
            EventBus.EventBus.Instance.onSceneLoaded -= InitializeStates;
        }
        private void InitializeStates()
        {
            _player = FindObjectOfType<Movement>();
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

        public void Interact()
        {
            _currentState.StartState();
        }
    }
}