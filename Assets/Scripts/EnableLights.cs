/* 
$$$$$$$\                      $$\ $$\       $$\    $$\          $$\ $$\                     
$$  __$$\                     \__|$$ |      $$ |   $$ |         $$ |$$ |                    
$$ |  $$ | $$$$$$\ $$\    $$\ $$\ $$ |      $$ |   $$ |$$$$$$\  $$ |$$ | $$$$$$\  $$\   $$\ 
$$ |  $$ |$$  __$$\\$$\  $$  |$$ |$$ |      \$$\  $$  |\____$$\ $$ |$$ |$$  __$$\ $$ |  $$ |
$$ |  $$ |$$$$$$$$ |\$$\$$  / $$ |$$ |       \$$\$$  / $$$$$$$ |$$ |$$ |$$$$$$$$ |$$ |  $$ |
$$ |  $$ |$$   ____| \$$$  /  $$ |$$ |        \$$$  / $$  __$$ |$$ |$$ |$$   ____|$$ |  $$ |
$$$$$$$  |\$$$$$$$\   \$  /   $$ |$$ |         \$  /  \$$$$$$$ |$$ |$$ |\$$$$$$$\ \$$$$$$$ |
\_______/  \_______|   \_/    \__|\__|          \_/    \_______|\__|\__| \_______| \____$$ |
                                                                                  $$\   $$ |
                                                                                  \$$$$$$  |
                                                                                   \______/ 
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

/*
 * Enable Lights when Player enters trigger
 * */
public class EnableLights : MonoBehaviour {
    
    [SerializeField] private CaptureOnTriggerEnter2D enableLightsTrigger;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D[] lightArray;
    [SerializeField] private float targetLightIntensity;
    [SerializeField] private float lightIntensitySpeed;

    private float lightIntensity;

    private void Start() {
        if (enableLightsTrigger != null) {
            enableLightsTrigger.OnPlayerTriggerEnter2D += EnableLightsTrigger_OnPlayerTriggerEnter2D;
        }
        
        foreach (UnityEngine.Experimental.Rendering.Universal.Light2D light in lightArray) {
            light.intensity = 0f;
        }

        enabled = false;
    }

    private void EnableLightsTrigger_OnPlayerTriggerEnter2D(object sender, System.EventArgs e) {
        TurnLightsOn();
        enableLightsTrigger.OnPlayerTriggerEnter2D -= EnableLightsTrigger_OnPlayerTriggerEnter2D;
    }

    private void Update() {
        lightIntensity += lightIntensitySpeed * Time.deltaTime;
        lightIntensity = Mathf.Clamp(lightIntensity, 0f, targetLightIntensity);

        foreach (UnityEngine.Experimental.Rendering.Universal.Light2D light in lightArray) {
            light.intensity = lightIntensity;
        }

        if (lightIntensity >= targetLightIntensity) {
            enabled = false;
        }
    }

    public void TurnLightsOn() {
        enabled = true;
    }

}
