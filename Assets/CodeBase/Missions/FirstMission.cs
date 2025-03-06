using System;
using System.Collections;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

namespace CodeBase.Missions
{
    public class FirstMission : MonoBehaviour,IMission
    {
        [SerializeField] private Transform _targetPlace;
        private TargetPlaceChecker _targetPlaceChecker;
        private MissionWaypoint markerTarget;
        
        public void MissionComplete()
        {
            print($"Yo man you win!");
            markerTarget._target = null;
        }
        public bool AllTasksWasCompleted()
        {
            if (_targetPlaceChecker.CheckPlayerPresenting())
                return true;
            
            return false;
        }
        public string ShowTasks()
        {
            if (_targetPlaceChecker.CheckPlayerPresenting())
                return "";
            return "Get to your destination!";
        }
        private void Start()
        {
            _targetPlaceChecker = _targetPlace.GetComponent<TargetPlaceChecker>();
        }
        public void StartMission()
        {
            markerTarget = ServiceLocator.Current.Get<MissionWaypoint>();
            markerTarget._target = _targetPlace;
        }
    }
}