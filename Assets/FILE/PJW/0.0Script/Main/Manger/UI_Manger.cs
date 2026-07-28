using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Main
{
    public class UI_Manger : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private CanvasGroup black_panel;


        [Header("RectTransfrom")]
        [SerializeField] private RectTransform _rectTransfrom1;
        [SerializeField] private RectTransform _rectTransfrom2;
        [SerializeField] private RectTransform _rectTransfrom3;


        //===========[Fade_In]==============
        private void Start()
        {
            black_panel.alpha = 1f;
            Fade_In();
        }

        private void Fade_In()
        {
            black_panel.DOFade(0f,1f);
        }


        //===========[Start Button]==============

        public void Big_Scale_Start_Button()
        {
            if (_rectTransfrom1 != null)
            {
                _rectTransfrom1.DOScale(6f, 0.5f);
            }
        }



        public void Small_Scale_Start_Button()
        {
            if (_rectTransfrom1 != null)
            {
                _rectTransfrom1.DOScale(5f, 0.5f);
            }
        }
        //===========[Setting Button]============
        public void Big_Scale_Setting_Button()
        {
            if (_rectTransfrom2 != null)
            {
                _rectTransfrom2.DOScale(6f, 0.5f);
            }
        }



        public void Small_Scale_Setting_Button()
        {
            if (_rectTransfrom2 != null)
            {
                _rectTransfrom2.DOScale(5f, 0.5f);
            }
        }

        //===========[Out Button]============
        public void Big_Scale_Out_Button()
        {
            if (_rectTransfrom3 != null)
            {
                _rectTransfrom3.DOScale(3f, 0.5f);
            }
        }



        public void Small_Scale_Out_Button()
        {
            if (_rectTransfrom3 != null)
            {
                _rectTransfrom3.DOScale(2.1f, 0.5f);
            }
        }
    }
}