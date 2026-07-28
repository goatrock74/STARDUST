using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Audio_Manger : MonoBehaviour
{
    [Header("Audi_Source")]
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource effect;


    [Header("Audio_Clip")]
    [SerializeField] private AudioClip music_Clip;
    //[SerializeField] private AudioClip effect_Clip;
    //추가




    [Header("Audio_Control")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;
    [SerializeField] private Slider masterSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")||PlayerPrefs.HasKey("EffectVolume")||PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetEffectVolume();
            SetMasterVolume();  
        }
        music.clip = music_Clip;
        music.Play();
    }

    public void SetMusicVolume()
    {
        float volume = Mathf.Max(musicSlider.value,0.0001f);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume",volume);
    }

    public void SetEffectVolume()
    {
        float volume = Mathf.Max(effectSlider.value,0.0001f);
        audioMixer.SetFloat("Effect",Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
    public void SetMasterVolume()
    {
        float volume = Mathf.Max(masterSlider.value,0.0001f);
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        musicSlider.value = volume;
        effectSlider.value = volume;
    }


    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            effectSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            effectSlider.value = PlayerPrefs.GetFloat("EffectVolume");
        }
    }

}
