using System;
using TMPro;
using UnityEngine;

namespace CodeBase.Missions
{
    public class MissionController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        public IMission _currentMission;


        private void Update()
        {
            if(_currentMission != null)Mission();
            print(_currentMission);
        }

        private void Mission()
        {
            _tmpText.text = _currentMission.ShowTasks();
            if (_currentMission.AllTasksWasCompleted())
            {
                _currentMission.MissionComplete();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                print($"Im colliding with npc");
                if (other.gameObject.TryGetComponent(out IMission mission))
                {
                    _currentMission = mission;
                    _currentMission.StartMission();
                print($"Im trying to get mission");
                }
            }
        }
    }
}