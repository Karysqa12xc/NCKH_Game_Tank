using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveTutorial : MonoBehaviour
{
    [SerializeField] private GameObject noticeMoveTutorial;
    [SerializeField] private Button quitButtonTutorial;
    [SerializeField] private Behaviour moveTankBehavior, reloadAmmo;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("turnOnMoveTutorial", 0.5f);
        quitButtonTutorial.onClick.AddListener(turnOffMoveTutorial);
    }
    public void turnOnMoveTutorial()
    {
        noticeMoveTutorial.SetActive(true);
        moveTankBehavior.enabled = false;
        reloadAmmo.enabled = false;
    }
    public void turnOffMoveTutorial()
    {
        noticeMoveTutorial.SetActive(false);
        moveTankBehavior.enabled = true;
    }

}
