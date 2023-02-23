using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillCooldown : MonoBehaviour
{
    public Image imageCooldown;
    [SerializeField]private Behaviour stopTeleport;
    public float coolDown = 15f;
    bool isCooldown;
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            isCooldown = true;
        }
        if(isCooldown){
            imageCooldown.fillAmount +=  1/coolDown * Time.deltaTime;
            stopTeleport.enabled = false;
            if(imageCooldown.fillAmount >= 1){
                imageCooldown.fillAmount = 0;
                stopTeleport.enabled = true;
                isCooldown = false;
            }
        }
    }
}
