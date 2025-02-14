using CodeBase.Patterns.State.NPC;
using CodeBase.Patterns.State.PlayerState;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyState : BaseNpcState
{
    public FriendlyState(FirstPersonController player,IStateSwitcher stateSwitcher,Animator animator,Image image) : base(player,stateSwitcher,animator,image)
    {
        
    }
    public override void StartState()
    {
        _npcAnimator.Play(StatesAnimation.Idle);
        _image.color = Color.green;
        if (_playerBehaviour.currentBehaviourState == PlayerBehaviour.PlayerBehaviourStates.Friendly)
            return;
        else if (_playerBehaviour.currentBehaviourState == PlayerBehaviour.PlayerBehaviourStates.Talker)_stateSwitcher.SwitchState<TalkingState>();
        else if(_playerBehaviour.currentBehaviourState == PlayerBehaviour.PlayerBehaviourStates.Agressive) _stateSwitcher.SwitchState<AgressiveState>();
    }

    public override void ExitState()
    {
        Debug.Log("Im friendly!");
    }

    public override void Fighting()
    {
    }

    public override void Talking()
    {
    }
}