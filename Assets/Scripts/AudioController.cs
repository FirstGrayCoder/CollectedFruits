using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("WrongFruit")]
    [SerializeField] AudioSource clipWrongFruit;
    [Header("DanceMusic")]
    [SerializeField] AudioSource danceMusic;

    public void Awake()
    {

    }

    public void PlayWrongFruit()
    {
        clipWrongFruit.Play();
    }

    public void PlayDanceMusic()
    {
        danceMusic.Play();
    }


}
