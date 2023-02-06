using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReloadAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI updateTextAmmo;
    [SerializeField] private int maxAmmo = 100, AmmoInCase = 6;
    [SerializeField] private Behaviour stopFireOfTank;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AmmoInCase--;
            if(AmmoInCase == 0 || maxAmmo == 0) stopFireOfTank.enabled = false;
            if(Input.GetKeyDown(KeyCode.R)){
                maxAmmo = maxAmmo -  AmmoInCase;
                AmmoInCase = AmmoInCase + (6 - AmmoInCase);
                if(AmmoInCase == 6) stopFireOfTank.enabled = true;
            }
        }

    }
}
