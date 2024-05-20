using TMPro;
using TrafficLights.Data;
using UnityEngine;

namespace TrafficLights.UI
{
    /// <summary>
    /// Controls the UI
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private DescriptionsConfig Descriptions;
        [SerializeField] private TMP_Text DesctiptionText;
        [SerializeField] private Alert Alert;

        private void Start()
        {
            GameManager.Instance.OnChangeTrafficLight += UpdateDescription;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnChangeTrafficLight -= UpdateDescription;
        }

        public void OnDriveButton()
        {
            Alert.ShowAlert(Descriptions.GetAlertDuration());
        }

        private void UpdateDescription()
        {
            LightState state = GameManager.Instance.GetClosestTrafficLight().CurrentState;
            Description description = Descriptions.GetByState(state);
            
            DesctiptionText.SetText(description.Text);
            Alert.HideAlert();
            Alert.SetText(description.Alert, description.AlertColor);
        }
    }
}