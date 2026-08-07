using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Net.NetworkInformation;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Question
{
    public class UI_Manger : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private CanvasGroup black_panel;


        [Header("Input_Field")]
        [SerializeField] private CanvasGroup visual_Input_field;
        [SerializeField] private TMP_InputField question_input_field;


        [Header("Show_Text")]
        [SerializeField] private TextMeshProUGUI whish_text;


        [Header("Show_Button")]
        [SerializeField] private Button check_button;
        [SerializeField] private TextMeshProUGUI check_text; 


        public Sequence question;
        public Sequence show_whish;

        private void Awake()
        {
            PlayerPrefs.DeleteKey("Whish_Value");
        }

        private void Start()
        {
            black_panel.alpha = 1f;
            whish_text.alpha = 0f;
            check_text.alpha = 0f;
            Fade_Out();   
        }
        //==========[Panel]===========
        private void Fade_Out()
        {
            black_panel.DOFade(0f,1f);
        }


        //===========[Input_Field]====
        public void Whish()
        {
            string whish = question_input_field.text;
            string save_whish_text;
            PlayerPrefs.SetString("Whish_Value", whish);
            save_whish_text=PlayerPrefs.GetString("Whish_Value");
            whish_text.text = ($"당신의 소원은 이제 {save_whish_text}입니다. 지금 바로 소원을 찾아 모험을 떠나보세요!");
            Show_Whish();
        }

        public void Show_Whish()
        {
            show_whish = DOTween.Sequence();
            question_input_field.interactable = false;
            check_button.interactable = true;
            show_whish.Append(visual_Input_field.DOFade(0f, 1f))
                    .AppendInterval(1.1f)
                    .Append(whish_text.DOFade(1f, 1f))
                    .Join(check_text.DOFade(1f, 1f))
                    .Play();

        }



        public void ChangeScene()
        {
            question = DOTween.Sequence();
            question.Append(black_panel.DOFade(1f, 1f))
            .Play().OnComplete(() => {SceneManager.LoadScene(3);});
        }
    }
}