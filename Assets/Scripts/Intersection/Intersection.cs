using System.Collections;
using TrafficLights.Data;
using UnityEngine;

namespace TrafficLights.Intersection
{
    /// <summary>
    /// Controls the Intersection
    /// </summary>
    public class Intersection : MonoBehaviour
    {
        [SerializeField] private IntersectionConfig Configs;
        [SerializeField] private TrafficLight[] TrafficLightsGroup1;
        [SerializeField] private TrafficLight[] TrafficLightsGroup2;

        private WaitForSeconds MinorDelay;
        private WaitForSeconds MajorDelay;
        
        private void Start()
        {
            StartCoroutine(TrafficLightUpdate());

            MinorDelay = new WaitForSeconds(Configs.GetMinorDelay());
            MajorDelay = new WaitForSeconds(Configs.GetMajorDelay());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator TrafficLightUpdate()
        {
            while (true)
            {
                foreach (TrafficStep step in Configs.GetSteps())
                {
                    SetLightGroup(TrafficLightsGroup1, step.LightState);
                    SetLightGroup(TrafficLightsGroup2, Configs.GetSeparateState(step.LightState));
                    
                    GameManager.Instance.OnChangeTrafficLight?.Invoke();
                    
                    yield return step.Priority == LightStatePriority.Minor ? MinorDelay : MajorDelay;
                }
            }
        }

        private void SetLightGroup(TrafficLight[] group, LightState state)
        {
            foreach (TrafficLight light in group)
            {
                light.SetState(state);
            }
        }
    }
}
