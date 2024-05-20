using UnityEngine;

namespace TrafficLights.Intersection
{
    /// <summary>
    /// Controls the traffic light
    /// </summary>
    public class TrafficLight : MonoBehaviour
    {
        [SerializeField] private MeshRenderer RedLight;
        [SerializeField] private MeshRenderer AmbientLight;
        [SerializeField] private MeshRenderer GreenLight;

        public LightState CurrentState
        {
            private set;
            get;
        }
        
        public void SetState(LightState state)
        {
            CurrentState = state;
            
            RedLight.enabled = state == LightState.Red || state == LightState.RedAmber;
            AmbientLight.enabled = state == LightState.Amber || state == LightState.RedAmber;
            GreenLight.enabled = state == LightState.Green;
        }
    }
}