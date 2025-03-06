using CodeBase.Patterns.EventBus;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
public class ServiceRegistration : MonoBehaviour
{
    
    private void OnEnable()
    {
        EventBus.Instance.onSceneLoaded += RegisterServices;
    }

    private void OnDisable()
    {
        EventBus.Instance.onSceneLoaded -= RegisterServices;
    }

    private void RegisterServices()
    {
        var a = FindObjectOfType<MissionWaypoint>();
        ServiceLocator.Current.Register(a);
    }

    
}
