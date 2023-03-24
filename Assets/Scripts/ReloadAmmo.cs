using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReloadAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI updateTextAmmo;
    [SerializeField] private GameObject reloadTutorial;
    [SerializeField] private int maxAmmo = 100, maxAmmoInCase = 6;
    [SerializeField] private Behaviour stopFireOfTank;
    [SerializeField] private AudioSource realoadSource;
    [SerializeField] private  AudioClip reloadClip;
    public int GetMaxAmmo() => maxAmmo;
    public int GetMaxAmmoInCase() => maxAmmoInCase;
    public int AdditionalAmmo() => maxAmmo = maxAmmo + 6;
    private void Start() {
        stopFireOfTank = GameObject.FindGameObjectWithTag("Player").GetComponent<TankFire>();
    }
    public void updateParameterOfBullet(){
        string updateBulletInCase = string.Format("Bullets: {0}/{1}", GetMaxAmmoInCase(), GetMaxAmmo());
        updateTextAmmo.text = updateBulletInCase;
    }
    public void Reload()
    {
         if (maxAmmoInCase == 0) {
            stopFireOfTank.enabled = false;
            reloadTutorial.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && maxAmmoInCase > 0)
        {
            maxAmmoInCase--;
            updateParameterOfBullet();
        }
         
        if (Input.GetKeyDown(KeyCode.R) && maxAmmo > 0)
        {
            if(maxAmmoInCase < 6) realoadSource.PlayOneShot(reloadClip);
            reloadTutorial.SetActive(false);
            if(maxAmmo < 6){
                if (maxAmmoInCase >= 0 && maxAmmoInCase < 6 || maxAmmoInCase == 1)
                {
                        maxAmmoInCase = maxAmmoInCase +  maxAmmo;
                        maxAmmo = maxAmmo - maxAmmo;
                        updateParameterOfBullet();
                }
            }
            if (maxAmmo > 1)
            {
                maxAmmo = maxAmmo - (6 - maxAmmoInCase);
                maxAmmoInCase = maxAmmoInCase + (6 - maxAmmoInCase);
                updateParameterOfBullet();
            }
            if (maxAmmoInCase <= 6) stopFireOfTank.enabled = true;
        }

    }
    void Update()
    {
        Reload();
    }
}
