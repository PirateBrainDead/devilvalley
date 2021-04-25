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

public class DissolveAnimate : MonoBehaviour {

    private Material material;
    private float dissolveAmount;
    private float dissolveSpeed;

    private void Update() {
        dissolveAmount += dissolveSpeed * Time.deltaTime;
        SetDissolveAmount();
    }

    private void SetDissolveAmount() {
        SetDissolveAmount(dissolveAmount);
    }

    private void SetDissolveAmount(float dissolveAmount) {
        this.dissolveAmount = dissolveAmount;
        if (material != null) material.SetFloat("_DissolveAmount", dissolveAmount);
    }

    public void StartDissolve(float startDissolveAmount, float dissolveSpeed) {
        this.dissolveSpeed = dissolveSpeed;
        dissolveAmount = startDissolveAmount;

        material = transform.Find("Body").GetComponent<MeshRenderer>().material;
        SetDissolveAmount();
    }


}
