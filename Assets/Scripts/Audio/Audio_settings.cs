using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Audio_settings : MonoBehaviour
{
    [Header("Mixer")]
    [SerializeField] AudioMixer mixer_;

    [Header("Sliders")]
    [SerializeField] Slider master_;
    [SerializeField] Slider music_;
    [SerializeField] Slider sfx_;

    private float masterVolume_;
    private float musicVolume_;
    private float sfxVolume_;

    private bool mutemaster_;
    private bool mutemusic_;
    private bool mutesfx_;

    public void SetMasterVolume()
    {

        float volume = master_.value;
        mixer_.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume()
    {

        float volume = music_.value;
        mixer_.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {

        float volume = sfx_.value;
        mixer_.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void MuteMaster()
    {
        if(mutemaster_ == false)
        {
            masterVolume_ = master_.value;
            master_.value = 0.001f;
            mutemaster_ = true;
        }
        else if(mutemaster_ == true)
        {
            master_.value = masterVolume_;
            mutemaster_ = false;
        }
        
        float volume = master_.value;
        mixer_.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void MuteMusic()
    {
        if(mutemusic_ == false)
        {
            musicVolume_ = music_.value;
            music_.value = 0.001f;
            mutemusic_ = true;
        }
        else if(mutemusic_ == true)
        {
            music_.value = musicVolume_;
            mutemusic_ = false;
        }
        
        float volume = music_.value;
        mixer_.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void MuteSFX()
    {
        if(mutesfx_ == false)
        {
            sfxVolume_ = sfx_.value;
            sfx_.value = 0.001f;
            mutesfx_ = true;
        }
        else if(mutesfx_ == true)
        {
            sfx_.value = sfxVolume_;
            mutesfx_= false;
        }
        
        float volume = sfx_.value;
        mixer_.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

}
