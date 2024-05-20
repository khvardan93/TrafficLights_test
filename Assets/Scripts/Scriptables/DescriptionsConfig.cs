using System;
using UnityEngine;

namespace TrafficLights.Data
{
    /// <summary>
    /// Contains descriptions for UI, and also some other information for UI
    /// </summary>
    [CreateAssetMenu(fileName = "DescriptionsConfig", menuName = "ScriptableObjects/DescriptionsConfig")]
    public class DescriptionsConfig : ScriptableObject
    {
        [SerializeField] private Description[] Descriptions;
        [Space] [SerializeField] private float AlertDuration = 2f;
        
        public Description GetByState(LightState state)
        {
            foreach (var description in Descriptions)
            {
                if (description.State == state)
                    return description;
            }
            
            return default;
        }

        public float GetAlertDuration()
        {
            return AlertDuration;
        }
    }
    
    [Serializable]
    public struct Description
    {
        public LightState State;
        [TextArea]
        public string Text;

        public string Alert;
        public Color AlertColor;
    }
}