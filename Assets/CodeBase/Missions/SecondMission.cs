using InfimaGames.LowPolyShooterPack;
using UnityEngine;
public class SecondMission : MonoBehaviour,IMission,IGameService
{
    [SerializeField] private Transform _barrelPlace;
    [SerializeField] private int _barrelsToWin;
    private int _currentCount;
    private MissionWaypoint markerTarget;
    
    public void MissionComplete()
    {
        print($"You win barrel challange!");
        markerTarget._target = null;
    }

    public bool AllTasksWasCompleted()
    {
        if (_currentCount == _barrelsToWin)
            return true;
        return false;
    }

    public void IncreaseBarrelCount()
    {
        _currentCount++;
    }

    public void StartMission()
    {
        markerTarget = ServiceLocator.Current.Get<MissionWaypoint>();
        markerTarget._target = _barrelPlace;
    }

    public string ShowTasks()
    {
        return "To win you need destroy " + _currentCount + " / " + _barrelsToWin;
    }
}