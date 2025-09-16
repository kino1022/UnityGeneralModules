using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GeneralModule.Spawner.Pattern.Encode {
    [IncludeInSettings(true)]
    public static class ConditionModule {
        
        public static bool TargetInRange(List<System.Type> components, Vector3 pos, float range) {
            UnityEngine.Collider[] objs = Physics.OverlapSphere(pos, range);

            foreach (var obj in objs) {
                foreach (var com in components) {
                    if (obj.GetComponent(com) is not null) return true;
                }
            }

            return false;
        }
        
        
    }
}