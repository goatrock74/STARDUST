using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGame
{
    public class SceneManger : MonoBehaviour
    {
        [Header("Panel_black")]
        [SerializeField] private CanvasGroup panel_black;


        [Header("stage1")]
        [SerializeField] private CanvasGroup text_stage1;

        private void Start()
        {
            panel_black.alpha = 1;
            text_stage1.alpha = 1;
            panel_black.DOFade(0f, 1f);
            text_stage1.DOFade(0f, 4f);
        }


        public void FadeOut()
        {
            panel_black.DOFade(1f, 1f).OnComplete(() => { SceneManager.LoadScene(1); });
        }
    }
}