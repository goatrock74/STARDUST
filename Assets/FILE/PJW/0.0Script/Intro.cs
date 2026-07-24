using DG.Tweening;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [Header("intro")]
    [SerializeField] private RectTransform sprite0;
    [SerializeField] private RectTransform sprite1;
    [SerializeField] private RectTransform sprite2;
    [SerializeField] private RectTransform sprite3;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup black_panle;


    Sequence intor;

    private void Start()
    {
        text.alpha = 0f;
        sprite0.localPosition = new Vector2(0f,1000f);
        sprite1.localPosition = new Vector2(0f,1000f);
        sprite2.localPosition = new Vector2(0f,1000f);
        sprite3.localPosition = new Vector2(0f,1000f);
        Show();
    }

    private void Show()
    {
        intor = DOTween.Sequence();
        intor.Append(sprite0.DOAnchorPosY((67f), 1f))
        .Append(sprite1.DOAnchorPosY((179f), 1f))
        .Append(sprite2.DOAnchorPosY((277f), 1f))
        .Append(sprite3.DOAnchorPosY((370f), 1f))
        .Append(text.DOFade(1f, 1.5f))
        .AppendInterval(2f)
        .Append(black_panle.DOFade(1f, 1f));
        intor.Play()
            .OnComplete(() => { SceneManager.LoadScene(1); });
    }
}
