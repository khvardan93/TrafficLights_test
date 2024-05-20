using System;
using UnityEngine;

namespace TrafficLights.Data
{
    /// <summary>
    /// Contains information how work the traffic lights in the Intersection
    /// </summary>
    [CreateAssetMenu(fileName = "IntersectionConfig", menuName = "ScriptableObjects/IntersectionConfig")]
    public class IntersectionConfig : ScriptableObject
    {
        [SerializeField] private TrafficStep[] LightSteps;
        [SerializeField] private float MinorDelay = 1f;
        [SerializeField] private float MajorDelay = 3f;
        [Space] 
        [SerializeField] private SeparateState[] SeparateStates;
        
        public TrafficStep[] GetSteps()
        {
            return LightSteps;
        }

        public float GetMinorDelay()
        {
            return MinorDelay;
        }
        
        public float GetMajorDelay()
        {
            return MajorDelay;
        }

        public LightState GetSeparateState(LightState state)
        {
            foreach (SeparateState item in SeparateStates)
            {
                if (item.State == state)
                    return item.Separate;
                
                if (item.Separate == state)
                    return item.State;
            }

            return default;
        }
    }

    [Serializable]
    public struct TrafficStep
    {
        public LightState LightState;
        public LightStatePriority Priority;
    }

    [Serializable]
    public struct SeparateState
    {
        public LightState State;
        public LightState Separate;
    }
}