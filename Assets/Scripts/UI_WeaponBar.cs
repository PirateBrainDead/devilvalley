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

public class UI_WeaponBar : MonoBehaviour {

    private void Start() {
        Player.Instance.OnPickedUpWeapon += Instance_OnPickedUpWeapon;
    }

    private void Instance_OnPickedUpWeapon(object sender, System.EventArgs e) {
        Weapon.WeaponType weaponType = (Weapon.WeaponType) sender;
        switch (weaponType) {
        case Weapon.WeaponType.Shotgun:
            transform.Find("shotgun").GetComponent<CanvasGroup>().alpha = 1f;
            break;
        case Weapon.WeaponType.Rifle:
            transform.Find("rifle").GetComponent<CanvasGroup>().alpha = 1f;
            break;
        }
    }

}
