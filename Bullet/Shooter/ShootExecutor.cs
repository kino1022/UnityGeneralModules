using System;
using GeneralModule.Bullet.Shooter.Interface;
using GeneralModule.Shooter.Data.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GeneralModule.Bullet.Shooter {
    public class ShootExecutor : SerializedMonoBehaviour, IShootExecutor {

        public void Shoot(IShootData data) {
            
        }

        protected Vector3 CalculateDirection(IShootData data) {

            if (data is null) {
                throw new ArgumentNullException();
            }

            if (data.Direction == Vector3.zero) {
                return Vector3.zero;
            }
            
            Quaternion baseRotation = Quaternion.LookRotation(data.Direction);

            return Vector3.zero;
        }
    }
}