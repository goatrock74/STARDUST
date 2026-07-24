using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Particle_Systeam_Manger : MonoBehaviour
{
    [Header("Start_Button")]
    [SerializeField] private ParticleSystem _ps1;


    [Header("Setting_Button")]
    [SerializeField] private ParticleSystem _ps2;


    [Header("Out_Button")]
    [SerializeField]private ParticleSystem _ps3;
    //===========[Start Button]==============
    public void Particle_Systeam_Start_Button()
    {
        if (_ps1 != null)
        {
            _ps1.Emit(20);
            _ps1.Stop();
            _ps1.Play();
        }
    }

    //===========[Setting Button]==============
    public void Particle_Systeam_Setting_Button()
    {
        if (_ps2 != null)
        {
            _ps2.Emit(20);
            _ps2.Stop();
            _ps2.Play();
        }
    }
    //===========[Out Button]==============
    public void Particle_Systeam_Out_Button()
    {
        if (_ps3 != null)
        {
            _ps3 .Emit(20);
            _ps3.Stop();
            _ps3.Play();
        }
    }
}
