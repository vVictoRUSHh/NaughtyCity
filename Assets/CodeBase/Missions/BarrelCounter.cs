using System;
using UnityEngine;

namespace CodeBase.Missions
{
    public class BarrelCounter : MonoBehaviour
    {
        [SerializeField] private SecondMission _secondMission;
        [SerializeField] private ExplosiveBarrelScript _explosiveBarrel;

        private void OnEnable()
        {
            _explosiveBarrel.onBarralExploded += IncreaseBarrelCurrentCount;
        }

        private void OnDestroy()
        {
            _explosiveBarrel.onBarralExploded -= IncreaseBarrelCurrentCount;
        }

        private void IncreaseBarrelCurrentCount()
        {
            _secondMission.IncreaseBarrelCount();
        }
    }
}