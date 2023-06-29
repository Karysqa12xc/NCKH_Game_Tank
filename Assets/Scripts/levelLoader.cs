using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
//Không sử dụng
public class levelLoader : MonoBehaviour
{
    public static levelLoader Instance;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private GameObject unActicePanel;
    [SerializeField]private Slider slider;

    public async void LoadLevel(int sceneIndex)
    {
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        scene.allowSceneActivation = false;
        loadingScene.SetActive(true);
        unActicePanel.SetActive(false);
        do
        {
            await Task.Delay(100);
            float progress = Mathf.Clamp01(scene.progress/.9f);
            slider.value = progress;
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScene.SetActive(true);
        unActicePanel.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            slider.value = progress;
            yield return null;
        }
    }
   
}
