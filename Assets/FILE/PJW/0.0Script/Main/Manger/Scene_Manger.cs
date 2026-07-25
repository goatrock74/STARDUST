using DG.Tweening;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manger : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private CanvasGroup black_panel;



    [Header("Main_Camera")]
    [SerializeField] private Transform main_camera;


    [Header("Text")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI start;
    [SerializeField] private TextMeshProUGUI setting;


    private Sequence main;

    public void ChangerScene()
    {
        main?.Kill();
        main = DOTween.Sequence();
        main.Append(title.DOFade(0f,1f).SetEase(Ease.OutCubic))
        .Join(start.DOFade(0f,1f).SetEase(Ease.OutCubic))
        .Join(setting.DOFade(0f,1f).SetEase(Ease.OutCubic))
        .Join(main_camera.DOMove(new Vector3(0f, -10f, 0f), 3f).SetEase(Ease.OutCubic))
        .Join(black_panel.DOFade(1f, 2f).SetEase(Ease.OutCubic))
        .SetLink(gameObject)
        .Play().OnComplete(() => { SceneManager.LoadScene(2);});
    }
}
