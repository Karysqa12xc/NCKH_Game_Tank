using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReloadAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI updateTextAmmo;
    [SerializeField] private int maxAmmo = 100, AmmoInCase = 6;
    [SerializeField] private Behaviour stopFireOfTank;

    public void Reload()
    {
        for (int i = AmmoInCase; i > 0;)
        {
            if (i == 0) break;
            if (Input.GetKeyDown(KeyCode.Mouse0)) i--;
            if (i == 0 || maxAmmo == 0) stopFireOfTank.enabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                maxAmmo = maxAmmo - i;
                i = i + (6 - i);
                if(i == 6) stopFireOfTank.enabled = true;
            }
        }

    }
    void Update()
    {
        Reload();
    }
}
