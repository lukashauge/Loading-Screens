using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] bool doFadeOutOnLoad;
    [SerializeField] Slider loadingBar;

    private Tween tween;
    private CanvasGroup group;

    void Start()
    {
        group = GetComponent<CanvasGroup>();

        if (doFadeOutOnLoad)
        {
            group.alpha = 1f;
            tween?.Kill();
            tween = group.DOFade(0, 2f).SetEase(Ease.Linear);
        } else
        {
            group.alpha = 0f;
        }
    }

    public void GoToScene(int sceneIndex)
    {
        tween?.Kill();
        loadingBar.gameObject.SetActive(false);
        tween = group.DOFade(1, 2f).SetEase(Ease.Linear).OnComplete(() => StartCoroutine(StartLoading(sceneIndex)));
    }

    private IEnumerator StartLoading(int sceneIndex)
    {
        loadingBar.gameObject.SetActive(true);
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loading.isDone)
        {
            loadingBar.value = loading.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    
}
