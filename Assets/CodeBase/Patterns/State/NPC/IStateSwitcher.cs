using CodeBase.Patterns.State.NPC;

public interface IStateSwitcher
{
    void SwitchState<T>() where T : BaseNpcState;
}