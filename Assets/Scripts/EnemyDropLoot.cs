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

public class EnemyDropLoot : MonoBehaviour {

    [SerializeField] private Transform lootTransform;
    private EnemyMain enemyMain;

    private void Awake() {
        enemyMain = GetComponent<EnemyMain>();
    }

    private void Start() {
        enemyMain.OnDestroySelf += EnemyMain_OnDestroySelf;
    }

    private void EnemyMain_OnDestroySelf(object sender, System.EventArgs e) {
        Instantiate(lootTransform, enemyMain.GetPosition(), Quaternion.identity);
    }

}
