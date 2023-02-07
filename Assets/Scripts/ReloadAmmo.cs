using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReloadAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI updateTextAmmo;
    [SerializeField] private int maxAmmo = 100, maxAmmoInCase = 6;
    [SerializeField] private Behaviour stopFireOfTank;
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && maxAmmoInCase > 0)
        {
            maxAmmoInCase--;
            string updateBulletInCase = string.Format("Bullets: {0}/{1}", maxAmmoInCase, maxAmmo);
            updateTextAmmo.text = updateBulletInCase;
        }
        if (maxAmmoInCase == 0) stopFireOfTank.enabled = false;
        if (Input.GetKeyDown(KeyCode.R) && maxAmmo > 0)
        {
            if (maxAmmo < 6)
            {
                if (maxAmmoInCase == 0)
                {
                    maxAmmoInCase = maxAmmoInCase + maxAmmo;
                    maxAmmo = maxAmmo - maxAmmo;
                    string updateBulletInCase = string.Format("Bullets: {0}/{1}", maxAmmoInCase, maxAmmo);
                    updateTextAmmo.text = updateBulletInCase;
                }
            }
            if (maxAmmo > 0)
            {
                maxAmmo = maxAmmo - (6 - maxAmmoInCase);
                maxAmmoInCase = maxAmmoInCase + (6 - maxAmmoInCase);
                string updateBulletInCase = string.Format("Bullets: {0}/{1}", maxAmmoInCase, maxAmmo);
                updateTextAmmo.text = updateBulletInCase;
            }

            if (maxAmmoInCase <= 6) stopFireOfTank.enabled = true;
        }

    }
    void Update()
    {
        Reload();
    }
}
