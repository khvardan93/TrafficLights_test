using System.Collections;
using TMPro;
using UnityEngine;

namespace TrafficLights.UI
{
    /// <summary>
    /// Controls the alert text
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class Alert : MonoBehaviour
    {
        private TMP_Text AlertText;
        
        private void Awake()
        {
            AlertText = GetComponent<TMP_Text>();
            SetState(false);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void SetState(bool state)
        {
            AlertText.enabled = state;
        }
        
        private IEnumerator AlertAnimation(float duration)
        {
            SetState(true);

            yield return new WaitForSeconds(duration);
            
            SetState(false);
        }

        public void ShowAlert(float duration)
        {
            if(AlertText.enabled)
                return;
            
            StartCoroutine(AlertAnimation(duration));
        }

        public void HideAlert()
        {
            SetState(false);
            StopAllCoroutines();
        }

        public void SetText(string alert, Color color)
        {
            AlertText.SetText(alert);
            AlertText.color = color;
        }
    }
}