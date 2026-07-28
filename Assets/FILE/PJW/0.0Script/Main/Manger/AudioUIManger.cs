using DG.Tweening;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioUIManger : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI background_sound_UI;
    [SerializeField] private TextMeshProUGUI effect_sound_UI;
    [SerializeField] private TextMeshProUGUI master_sound_UI;


    [Header("Out_Button")]
    [SerializeField] private TextMeshProUGUI out_button_T;
    [SerializeField] private Button out_button;
    [SerializeField] private EventTrigger out_trigger;


    [Header("Start_Button")]
    [SerializeField] private RectTransform start_rectTransform;
    [SerializeField] private TextMeshProUGUI start_button_T;
    [SerializeField] private Button start_button;
    [SerializeField] private EventTrigger start_trigger;


    [Header("Setting_Button")]
    [SerializeField] private RectTransform setting_rectTransform;
    [SerializeField] private TextMeshProUGUI setting_button_T;
    [SerializeField] private Button setting_button;
    [SerializeField] private EventTrigger setting_trigger;


    [Header("Music_Slider")]
    [SerializeField] private  Slider music_slider;
    [SerializeField] private Image music_slider_image;
    [SerializeField] private Image music_slider_handle;
    [SerializeField] private Image music_slider_fill;


    [Header("Effect_Slider")]
    [SerializeField] private Slider effect_slider;
    [SerializeField] private Image effect_slider_image;
    [SerializeField] private Image effect_slider_handle;
    [SerializeField] private Image effect_slider_fill;


    [Header("Master_Slider")]
    [SerializeField] private Slider master_slider;
    [SerializeField] private Image master_slider_image;
    [SerializeField] private Image master_slider_handle;
    [SerializeField] private Image master_slider_fill;

    private Sequence sound_show;
    private Sequence sound_hide; 

    private void Awake()
    {
        out_button.interactable = false;
        out_trigger.enabled = false;
        music_slider.interactable = false;
        background_sound_UI.alpha = 0f;
        effect_sound_UI.alpha = 0f;
        master_sound_UI.alpha = 0f;
        out_button_T.alpha = 0f;
        music_slider_image.color = new Color(255f,255f,255f,0f);
        music_slider_handle.color = new Color(255f, 255f, 255f, 0f);
        music_slider_fill.color = new Color(255f,255f,255f,0f);
        effect_slider_image.color = new Color(255f, 255f, 255f, 0f);
        effect_slider_handle.color = new Color(255f, 255f, 255f, 0f);
        effect_slider_fill.color = new Color(255f, 255f, 255f, 0f);
        master_slider_image.color =  new Color(255f,255f,255f, 0f);
        master_slider_handle.color = new Color(255f, 255f, 255f, 0f);
        master_slider_fill.color = new Color(255f, 255f, 255f, 0f);
    }
    public void Show_Menu()
    {

        out_button.interactable = true;
        out_trigger.enabled = true;
        music_slider.interactable = true;
        start_button.interactable = false;
        start_trigger.enabled = false;
        setting_button.interactable = false;
        setting_trigger.enabled = false;
        sound_show?.Kill();
        sound_show = DOTween.Sequence();
        sound_show.Append(start_button_T.DOFade(0f, 1f))
        .Join(setting_button_T.DOFade(0f, 1f))
        .Append(background_sound_UI.DOFade(1f, 1f))
        .Join(effect_sound_UI.DOFade(1f, 1f))
        .Join(master_sound_UI.DOFade(1f, 1f))
        .Join(out_button_T.DOFade(1f, 1f))
        .Join(music_slider_image.DOFade(1f, 1f))
        .Join(music_slider_handle.DOFade(1f, 1f))
        .Join(music_slider_fill.DOFade(1f, 1f))
        .Join(effect_slider_image.DOFade(1f, 1f))
        .Join(effect_slider_handle.DOFade(1f, 1f))
        .Join(effect_slider_fill.DOFade(1f, 1f))
        .Join(master_slider_image.DOFade(1f,1f))
        .Join(master_slider_handle.DOFade(1f,1f))
        .Join(master_slider_fill.DOFade(1f,1f))
        .SetLink(gameObject)
        .Play();
    }
    
    public void Hide_Menu()
    {

        sound_hide?.Kill();
        sound_hide = DOTween.Sequence();
        sound_hide.Append(background_sound_UI.DOFade(0f, 1f))
        .Join(effect_sound_UI.DOFade(0f, 1f))
        .Join(master_sound_UI.DOFade(0f, 1f))
        .Join(out_button_T.DOFade(0f, 1f))
        .Join(music_slider_image.DOFade(0f,1f))
        .Join(music_slider_handle.DOFade(0f,1f))
        .Join(music_slider_fill.DOFade(0f,1f))
        .Join(effect_slider_image.DOFade(0f,1f))
        .Join(effect_slider_handle.DOFade(0f,1f))
        .Join(effect_slider_fill.DOFade(0f,1f))
        .Join(master_slider_image.DOFade(0f,1f))
        .Join(master_slider_handle.DOFade(0f,1f))
        .Join(master_slider_fill.DOFade(0f,1f))
        .Append(start_button_T.DOFade(1f, 1f))
        .Join(setting_button_T.DOFade(1f, 1f))
        .JoinCallback(() =>
        {
            out_button.interactable = false;
            out_trigger.enabled = false;
            music_slider.interactable = false;
            start_button.interactable = true;
            start_trigger.enabled = true;
            start_rectTransform.localScale = Vector3.one*5;
            setting_button.interactable = true;
            setting_trigger.enabled = true;
           setting_rectTransform.localScale = Vector3.one*5;
        })
        .SetLink(gameObject)
        .Play();
    }
}
