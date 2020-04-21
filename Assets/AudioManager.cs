using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    private AudioSource source;
    [Range(0f, 1f)]
    public float volume = 0.7f;

    [Range(0.5f, 1.5f)]
    public float pitch = 1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
    }
}


    //add to variable list
//private AudioManager myDJ;

    //change string in editor
//public string spawnSoundName;

    //put in start
//myDJ = AudioManager.instance;
//if (myDJ == null){Debug.LogError ("No DJ found!");}

    //put where to play sound
//myDJ.PlaySound(spawnSoundName);

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one audio manager in the scene");
        }else
        {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
        }

        PlaySound("Fireball");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //
        Debug.LogWarning("Sound name not found: " + _name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound("Fireball");

        }
    }

}
