using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
   [SerializeField] PlayerBody playerHealth;
    [SerializeField] Slider healthSlider;
    private void Update() {
        healthSlider.value = playerHealth.GetHealth();
    }
    private void Start() {
        healthSlider.maxValue = playerHealth.GetHealth();
    }
}
