using DG.Tweening;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InGame
{
    public class UIManger : MonoBehaviour
    {
        [Header("Music")]
        [SerializeField] private TextMeshProUGUI music_text;
        [SerializeField] private Slider music_slider;
        [SerializeField] private RectTransform music_slider_RT;


        [Header("Effect")]
        [SerializeField] private TextMeshProUGUI effect_text;
        [SerializeField] private Slider effect_slider;
        [SerializeField] private RectTransform effect_slider_RT;


        [Header("Master")]
        [SerializeField] private TextMeshProUGUI master_text;
        [SerializeField] private Slider master_slider;
        [SerializeField] private RectTransform master_slider_RT;




        private Sequence menu_show;
        private Sequence menu_down;
        bool isOpen = false;

        private void Start()
        {
            music_text.rectTransform.localPosition = new Vector2 (music_text.rectTransform.localPosition.x, 800f);
            music_slider_RT.localPosition = new Vector2(music_slider_RT.localPosition.x, 800f);
            music_slider.interactable = false;

            effect_text.rectTransform.localPosition = new Vector2(effect_text.rectTransform.localPosition.x, 800f);
            effect_slider_RT.localPosition = new Vector2(effect_slider_RT.localPosition.x, 800f);
            effect_slider.interactable = false;

            master_text.rectTransform.localPosition = new Vector2(master_text.rectTransform.localPosition.x, 800f);
            master_slider_RT.localPosition = new Vector2(master_slider_RT.localPosition.x, 800f);
            master_slider.interactable = false;
        }

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (!isOpen)
                {
                    Show();
                }
                else
                {
                    Down();
                }
            }
        }

        private void Show()
        {
            menu_show = DOTween.Sequence();
            menu_show.Append(music_text.rectTransform.DOAnchorPosY(75f, 1f))
                .Join(music_slider_RT.DOAnchorPosY(69.552f, 1f))
                .Join(effect_text.rectTransform.DOAnchorPosY(-43f, 1f))
                .Join(effect_slider_RT.DOAnchorPosY(-36, 1f))
                .Join(master_text.rectTransform.DOAnchorPosY(-154.7f, 1f))
                .Join(master_slider_RT.DOAnchorPosY(-153f, 1f))
                .Play().OnComplete(() =>
                {
                    music_slider.interactable = true;
                    effect_slider.interactable = true;
                    master_slider.interactable = true;
                    isOpen = true;
                });
        }

        private void Down()
        {
            menu_down = DOTween.Sequence();
            menu_down.Append(music_text.rectTransform.DOAnchorPosY(800f, 1f))
                .Join(music_slider_RT.DOAnchorPosY(800f, 1f))
                .Join(effect_text.rectTransform.DOAnchorPosY(800f, 1f))
                .Join(effect_slider_RT.DOAnchorPosY(800f, 1f))
                .Join(master_text.rectTransform.DOAnchorPosY(800f, 1f))
                .Join(master_slider_RT.DOAnchorPosY(800f, 1f))
                .Play().OnComplete(() =>
                {
                    music_slider.interactable = false;
                    effect_slider.interactable = false;
                    master_slider.interactable = false;
                    isOpen = false;
                });
        }
    }
}