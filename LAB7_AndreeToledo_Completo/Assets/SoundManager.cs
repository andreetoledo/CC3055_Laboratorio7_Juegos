using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sonidoMuerte, sonidoSalto, sonidoGolpe, sonidoOver, sonidoPower, sonidoEnemy;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        sonidoGolpe = Resources.Load<AudioClip>("GolpeEnemy");
        sonidoMuerte = Resources.Load<AudioClip>("Golpe");
        sonidoSalto = Resources.Load<AudioClip>("Salto");
        sonidoPower = Resources.Load<AudioClip>("Zelda");
        sonidoOver = Resources.Load<AudioClip>("muerteSong");
        sonidoEnemy = Resources.Load<AudioClip>("muerteEnemy");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Golpe":
                audioSrc.PlayOneShot(sonidoMuerte);
                break;
            case "Salto":
                audioSrc.PlayOneShot(sonidoSalto);
                break;
            case "Zelda":
                audioSrc.PlayOneShot(sonidoPower);
                break;
            case "muerteSong":
                audioSrc.PlayOneShot(sonidoOver);
                break;
            case "GolpeEnemy":
                audioSrc.PlayOneShot(sonidoGolpe);
                break;
            case "muerteEnemy":
                audioSrc.PlayOneShot(sonidoEnemy);
                break;

        }
    }

}
