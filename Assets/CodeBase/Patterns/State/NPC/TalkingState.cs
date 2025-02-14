using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Patterns.State.NPC;
using CodeBase.Patterns.State.PlayerState;
using UnityEngine;
using UnityEngine.UI;

public class TalkingState : BaseNpcState
{
    private List<string> _dialogList = new List<string>()
    {
        "Привет,дружище!",
        "Ты что-то хотел?",
        "Что ты хочешь ответь!",
        "Хочешь пизды хапнуть дура!",
        "Шуруй давай!",
        "Чепуха",
        "!"
    };

    private PlayerInteracter _playerInteracter;
    public TalkingState(FirstPersonController player,IStateSwitcher stateSwitcher,Animator animator,Image image) : base(player,stateSwitcher,animator,image)
    {
        _playerInteracter = player.GetComponent<PlayerInteracter>();
    }

    public override void StartState()
    {
        
        if (_playerBehaviour.currentBehaviourState == PlayerBehaviour.PlayerBehaviourStates.Talker)
        {
            _image.color = Color.yellow;
            Talking();
        }
        else
        {
            _stateSwitcher.SwitchState<AgressiveState>();
        }
    }

    public override void ExitState()
    {
        Debug.Log("Im finish talking with you!");
    }

    public override void Fighting()
    {
    }

    public override async void Talking()
    {
        
        _npcAnimator.Play(StatesAnimation.Talking);
        _player._inputService._isMovementLocked = true;
        Debug.LogError(_dialogList.Count);

        // Ждем завершения асинхронного метода
        await DisplayDialogAsync(_playerInteracter);

        Debug.Log(_playerInteracter._text.text); // Теперь корректно выводит текст
    }

    private async Task DisplayDialogAsync(PlayerInteracter playerInteracter)
    {
        for (int i = 0; i < _dialogList.Count; i++)
        {
            playerInteracter._text.text = _dialogList[i];

            Debug.Log($"Showing text: {_dialogList[i]}"); // Отладка текста

            // Ждем нажатие клавиши "E" перед переходом к следующей реплике
            await WaitForKeyPress(KeyCode.Y);
        }

        // Конец диалога
        playerInteracter._dialogRepliceCount = 0;
        _player._inputService._isMovementLocked = false;
    }

    private async Task WaitForKeyPress(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            await Task.Yield(); // Ждем следующий кадр
        }

        await Task.Delay(100); // Задержка для предотвращения мгновенного пропуска реплик
    }

}