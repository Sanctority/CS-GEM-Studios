﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Public variables
    public static AudioManager _instance;
    public AudioClip _mainMenuMusic;                // Main menu audio clip
    public AudioClip _gameMusic;                    // Main game audio clip
    public AudioClip _shopMusic;                    // Main shop audio clip
    public AudioClip _gameOverMusic;                // Main space level audio clip
    public AudioClip _spaceMusic;                   // Game Over audio clip

    // Private variables
    private AudioSource _audioSource;

    private void Awake()
    {
        // Instance of game manager start.
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        // Instance of game manager end.
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);                      // Make sure the Audio Source stays alive through scene changes
        _audioSource = GetComponent<AudioSource>();
        SceneManager.activeSceneChanged += SceneChanged;    // Subscribe to the activeSceneChanged event

        _audioSource.volume = 1f;                        // Set audio to a low amount, its still loud, might want to clamp it
        _audioSource.loop = true;                           // Set audio to loop
        _audioSource.clip = _mainMenuMusic;                 // Audio Source will load on main menu when game loads, which does not call the activeSceneChanged event, so assign it here
        _audioSource.Play();                                // Play the menu music
    }

    private void SceneChanged(Scene current, Scene next)
    {
        _audioSource.Stop();
        switch (next.buildIndex)
        {
            default:
            case 0:
                {
                    _audioSource.clip = _mainMenuMusic; // Change the clip
                }
                break;
            case 1:
                {
                    _audioSource.clip = _spaceMusic;     // Change the clip
                }
                break;
            case 2:
                {
                    _audioSource.clip = _shopMusic;     // Change the clip
                }
                break;
            case 3:
                {
                    _audioSource.clip = _gameOverMusic;     // Change the clip
                }
                break;
            case 4:
                {
                    
                    _audioSource.clip = _gameMusic;     // Change the clip
                }
                break;
        }
        _audioSource.Play();
    }

    public void ChangeVolume(float _vol)
    {
        _audioSource.volume = _vol;             // Exposed function for setting volume which we can clamp
    }
}
