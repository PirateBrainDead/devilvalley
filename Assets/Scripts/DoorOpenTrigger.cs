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

public class DoorOpenTrigger : MonoBehaviour {

    [SerializeField] private CaptureOnTriggerEnter2D captureOnTriggerEnter2D;
    [SerializeField] private DoorAnims doorAnims;

    private void Awake() {
        captureOnTriggerEnter2D.OnPlayerTriggerEnter2D += DoorOpenTrigger_OnPlayerTriggerEnter2D;
    }

    private void DoorOpenTrigger_OnPlayerTriggerEnter2D(object sender, System.EventArgs e) {
        doorAnims.SetColor(DoorAnims.ColorName.Green);
        doorAnims.OpenDoor();
        captureOnTriggerEnter2D.OnPlayerTriggerEnter2D -= DoorOpenTrigger_OnPlayerTriggerEnter2D;
    }

}
