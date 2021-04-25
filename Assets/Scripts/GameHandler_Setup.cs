﻿/* 
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
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;
using GridPathfindingSystem;

public class GameHandler_Setup : MonoBehaviour {

    public static GameHandler_Setup Instance { get; private set; }
    public static GridPathfinding gridPathfinding;

    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Transform followTransform;
    [SerializeField] private bool cameraPositionWithMouse;
    [SerializeField] private UI_Weapon uiWeapon;

    [SerializeField] private Player player;

    [SerializeField] private DoorAnims doorAnims;
    [SerializeField] private Transform pfPathfindingUnWalkable;
    [SerializeField] private Transform pfPathfindingWalkable;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Sound_Manager.Init();
        cameraFollow.Setup(GetCameraPosition, () => 60f, true, true);

        Vector3 pathfindingLowerLeft = transform.Find("PathfindingLowerLeft").position;
        Vector3 pathfindingUpperRight = transform.Find("PathfindingUpperRight").position;

        gridPathfinding = new GridPathfinding(pathfindingLowerLeft, pathfindingUpperRight, 5f);
        gridPathfinding.RaycastWalkable(1 << GameAssets.i.wallLayer);
        //gridPathfinding.PrintMap(pfPathfindingWalkable, pfPathfindingUnWalkable);

        //Enemy enemy = Enemy.Create(player.GetPosition() + new Vector3(+60, 0));
        //enemy.EnemyMain.EnemyTargeting.SetGetTarget(() => player);

        uiWeapon.SetWeapon(player.GetWeapon());
        player.OnWeaponChanged += Player_OnWeaponChanged;

        FunctionTimer.Create(() => doorAnims.OpenDoor(), 3f);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) {
            PauseGame();
            UI_Controls.Instance.Show();
        }
    }

    private void Player_OnWeaponChanged(object sender, System.EventArgs e) {
        uiWeapon.SetWeapon(player.GetWeapon());
    }

    private Vector3 GetCameraPosition() {
        if (cameraPositionWithMouse) {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 playerToMouseDirection = mousePosition - followTransform.position;
            return followTransform.position + playerToMouseDirection * .3f;
        } else {
            return followTransform.position;
        }
    }

    private void SpawnEnemy() {
        Enemy enemy = Enemy.Create(player.GetPosition() + UtilsClass.GetRandomDir() * 40f, Enemy.EnemyType.Archer);
        enemy.EnemyMain.EnemyTargeting.SetGetTarget(() => player);
    }

    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }
}
