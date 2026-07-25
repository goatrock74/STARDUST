using UnityEngine;
using UnityEngine.UI;

public class Audio_Manger : MonoBehaviour
{
    private AudioSource audioSurce;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        audioSurce = this.GetComponent<AudioSource>();

        volumeSlider.onValueChanged.AddListener(delegate { UpdateVolumeSlider(); });
    }

    public void UpdateVolumeSlider()
    {
        audioSurce.volume = volumeSlider.value;
    }
}
