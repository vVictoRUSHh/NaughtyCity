using CodeBase.Patterns.State.NPC;
using CodeBase.Patterns.State.PlayerState;
using UnityEngine;
using UnityEngine.UI;

public class AgressiveState : BaseNpcState
{
    public AgressiveState(FirstPersonController player,IStateSwitcher stateSwitcher,Animator animator,Image image) : base(player,stateSwitcher,animator,image)
    {
        
    }
    
    public override void StartState()
    {
        if (_playerBehaviour.currentBehaviourState != PlayerBehaviour.PlayerBehaviourStates.Agressive)
        {
            _stateSwitcher.SwitchState<FriendlyState>();
        }
        else
        {
            Fighting();
            _image.color = Color.red;
        }
    }

    public override void ExitState()
    {
        Debug.Log("Lets see!");
    }

    public override void Fighting()
    {
        Debug.Log("Im fighting awwww!");
        _npcAnimator.Play(StatesAnimation.Agressive);
    }

    public override void Talking()
    {
    }

}