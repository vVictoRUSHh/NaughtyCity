using CodeBase.Patterns.State.PlayerState;
using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.Patterns.State.NPC
{
    public abstract class BaseNpcState
    {
        public FirstPersonController _player;
        public IStateSwitcher _stateSwitcher;
        public PlayerBehaviour _playerBehaviour;
        public Animator _npcAnimator;
        public Image _image;
        public BaseNpcState(FirstPersonController player, IStateSwitcher stateSwitcher, Animator animator,Image image)
        {
            _player = player;
            _stateSwitcher = stateSwitcher;
            _playerBehaviour = player.GetComponent<PlayerBehaviour>();
            _npcAnimator = animator;
            _image = image;
        }

        public abstract void StartState();
        public abstract void ExitState();
        public abstract void Fighting();
        public abstract void Talking();
    }
}