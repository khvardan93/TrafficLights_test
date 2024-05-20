using System;
using TrafficLights.Intersection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TrafficLights
{
    /// <summary>
    /// Controls game's basic 
    /// </summary>
    public class GameManager
    {
        private static GameManager CachedInstance;
        public static GameManager Instance => CachedInstance ?? (CachedInstance = new GameManager());

        private TrafficLight[] TrafficLights;
        private GameObject Character;

        public Action OnChangeTrafficLight;

        private GameManager()
        {
            TrafficLights = Object.FindObjectsOfType<TrafficLight>();
            Character = GameObject.FindWithTag("Character");
        }

        /// <summary>
        /// Returns the closes traffic line to the player, which forward vector looks at the player, as same as players forward vector
        /// </summary>
        /// <returns>TrafficLight instance</returns>
        public TrafficLight GetClosestTrafficLight()
        {
            TrafficLight closestTrafficLight = null;
            float closestDistance = Mathf.Infinity;
            Vector3 characterForward = Character.transform.forward;
            Vector3 characterPosition = Character.transform.position;

            foreach (TrafficLight trafficLight in TrafficLights)
            {
                Vector3 toTrafficLight = trafficLight.transform.position - characterPosition;
                float distance = toTrafficLight.magnitude;
                float playerToLightDot = Vector3.Dot(characterForward, toTrafficLight.normalized);
                float lightToPlayerDot = Vector3.Dot(trafficLight.transform.forward, -toTrafficLight.normalized);

                if (playerToLightDot > 0 && lightToPlayerDot > 0 && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTrafficLight = trafficLight;
                }
            }

            return closestTrafficLight;
        }
    }
}