using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.InputSystem;
using System.Net.NetworkInformation;
using UnityEngine.SceneManagement;

namespace Question
{
    public class UI_Manger : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private CanvasGroup black_panel;


        [Header("Input_Field")]
        [SerializeField] private TMP_InputField question_input_field;


        public Sequence question;

        private void Awake()
        {
            PlayerPrefs.DeleteKey("Whish_Value");
        }

        private void Start()
        {
            black_panel.alpha = 1f;
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
            PlayerPrefs.SetString("Whish_Value", whish);
            ChangeScene();
        }

        private void ChangeScene()
        {
            question = DOTween.Sequence();
            question.Append(black_panel.DOFade(1f, 1f))
            .Play().OnComplete(() => {SceneManager.LoadScene(3);});
        }
    }
}