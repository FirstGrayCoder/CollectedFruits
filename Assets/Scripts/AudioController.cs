using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("WrongFruit")]
    [SerializeField] AudioSource clipWrongFruit;

    public void Awake()
    {

    }

    public void PlayWrongFruit()
    {
        clipWrongFruit.Play();
    }

}
