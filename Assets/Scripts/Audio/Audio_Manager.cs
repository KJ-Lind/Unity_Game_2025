using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource Music_;
    [SerializeField] AudioSource SFX_;

    [Header("Clips")]
    [SerializeField] AudioClip[] Audios_;

    public static Audio_Manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Music_.clip = Audios_[0];
        Music_.Play();
    }

    public void PlaySound(int sound)
    {
        SFX_.PlayOneShot(Audios_[sound]);
    }
}
