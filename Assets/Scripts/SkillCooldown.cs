using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillCooldown : MonoBehaviour
{
    public Image[] imageCooldown;
    [SerializeField] private Behaviour stopTeleport, stopPlanting;
    public float coolDownTele = 15f, coolDownPlan= 10f;
    bool isCooldownTele, isCoolDownPlan;
    [SerializeField] private TakeItems quantityBomb;
    private void Start() 
    {
        quantityBomb = GameObject.Find("TankBlueMain").GetComponent<TakeItems>();
        stopTeleport = GameObject.Find("TankBlueMain").GetComponent<Teleport>();
        stopPlanting = GameObject.Find("TankBlueMain").GetComponent<PlantingBomb>();
    }
    void Update()
    {
        Invoke("CoolDownSkill", .5f);
    }

    private void CoolDownSkill()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isCooldownTele = true;
        }
        if(Input.GetKeyDown(KeyCode.X) && quantityBomb.GetBomb() > 0)
        {
            isCoolDownPlan = true;
        }
        if(isCoolDownPlan){
            imageCooldown[1].fillAmount += 1 / coolDownPlan * Time.deltaTime;
            stopPlanting.enabled = false;
            if(imageCooldown[1].fillAmount >= 1){
                imageCooldown[1].fillAmount = 0;
                stopPlanting.enabled = true;
                isCoolDownPlan = false;
            }
        }
        if (isCooldownTele)
        {
            imageCooldown[0].fillAmount += 1 / coolDownTele * Time.deltaTime;
            stopTeleport.enabled = false;   
            if (imageCooldown[0].fillAmount >= 1)
            {
                imageCooldown[0].fillAmount = 0;
                stopTeleport.enabled = true;
                isCooldownTele = false;
            }
        }
    }

}
