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
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureOnTriggerEnter2D : MonoBehaviour {

    public event EventHandler OnCapturedTriggerEnter2D;
    public event EventHandler OnPlayerTriggerEnter2D;

    private void OnTriggerEnter2D(Collider2D collider) {
        OnCapturedTriggerEnter2D?.Invoke(collider, EventArgs.Empty);

        Player player = collider.GetComponent<Player>();
        if (player != null) {
            OnPlayerTriggerEnter2D?.Invoke(player, EventArgs.Empty);
        }
    }

}
