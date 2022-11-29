using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealBar : MonoBehaviour
{
    [SerializeField]private Image healthbar;
    public void UpdateHealth(float maxHealth , float curentHealth){
        healthbar.fillAmount = curentHealth / maxHealth;
    }
}
