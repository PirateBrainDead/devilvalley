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

public class DoorStartState : MonoBehaviour {

    [SerializeField] private bool startOpen;
    [SerializeField] private DoorAnims.ColorName doorColor;

    private void Start() {
        DoorAnims doorAnims = GetComponent<DoorAnims>();
        if (startOpen) {
            doorAnims.OpenDoor();
        } else {
            doorAnims.CloseDoor();
        }

        doorAnims.SetColor(doorColor);
    }

}
