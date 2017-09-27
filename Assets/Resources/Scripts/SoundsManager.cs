using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {

    AudioSource myAS;

    public AudioClip ak47Sound;
    public AudioClip batterySound;
    public AudioClip bubbleSound;
    public AudioClip pistolSound;
    public AudioClip glockSound;
    public AudioClip uziSound;
    public AudioClip rifleSound;
    public AudioClip shotgunSound;
    public AudioClip tazerSound;
    public AudioClip orbGunSound;
    public AudioClip laserGunSound;
    public AudioClip bazookaSound;

    public AudioClip shellCasingSound;

    public AudioClip bulletHitSound;
    public AudioClip explosionSound;
    public AudioClip throwSound;
    public AudioClip projectileHitSound;
    public AudioClip brokenGlassSound;
    public AudioClip sawHitSound;
    public AudioClip bulletExplodeSound;
    public AudioClip bulletImpactSound;

    public AudioClip zombieSound1;
    public AudioClip zombieSound2;
    public AudioClip zombieSound3;
    public AudioClip zombieSound4;
    public AudioClip zombieSound5;
    public AudioClip zombieSound6;
    public AudioClip zombieSound7;
    public AudioClip zombieSound8;
    public AudioClip zombieSound9;
    public AudioClip zombieSound10;
    public AudioClip zombieSound11;
    public AudioClip zombieSound12;
    public AudioClip zombieSound13;
    public AudioClip zombieSound14;

	// Use this for initialization
	void Start () 
    {
        myAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void playGunSound(string name)
    {
  
        switch(name)
        {
            case "ak-47(Clone)":                
                myAS.PlayOneShot(ak47Sound);                
                break;
            case "battery gun(Clone)":                               
                myAS.PlayOneShot(batterySound);                
                break;
            case "bubble gun(Clone)":
                myAS.PlayOneShot(bubbleSound);
                break;
            case "pistol(Clone)":
                myAS.PlayOneShot(pistolSound);
                break;
            case "glock(Clone)":
                myAS.PlayOneShot(glockSound);
                break;
            case "uzi(Clone)":
                myAS.PlayOneShot(uziSound);
                break;
            case "rifle(Clone)":
                myAS.PlayOneShot(rifleSound);
                break;
            case "shot gun(Clone)":
                myAS.PlayOneShot(shotgunSound);
                break;
            case "tazer(Clone)":
                myAS.PlayOneShot(tazerSound);
                break;
            case "orb gun(Clone)":
                myAS.PlayOneShot(orbGunSound);
                break;
            case "laser gun(Clone)":
                myAS.PlayOneShot(laserGunSound);
                break;
            case "bazooka(Clone)":
                myAS.PlayOneShot(bazookaSound);
                break;
            default :
                return;
        }
    }


    public void playZombieSound(int index)
    {
        switch(index)
        {
            case 1 :
                myAS.PlayOneShot(zombieSound1);
                break;
            case 2:
                myAS.PlayOneShot(zombieSound2);
                break;
            case 3:
                myAS.PlayOneShot(zombieSound3);
                break;
            case 4:
                myAS.PlayOneShot(zombieSound4);
                break;
            case 5:
                myAS.PlayOneShot(zombieSound5);
                break;
            case 6:
                myAS.PlayOneShot(zombieSound6);
                break;
            case 7:
                myAS.PlayOneShot(zombieSound7);
                break;
            case 8:
                myAS.PlayOneShot(zombieSound8);
                break;
            case 9:
                myAS.PlayOneShot(zombieSound9);
                break;
            case 10:
                myAS.PlayOneShot(zombieSound10);
                break;
            case 11:
                myAS.PlayOneShot(zombieSound11);
                break;
            case 12:
                myAS.PlayOneShot(zombieSound12);
                break;
            case 13:
                myAS.PlayOneShot(zombieSound13);
                break;
            case 14:
                myAS.PlayOneShot(zombieSound14);
                break;
            default:
                return;
        }
    }

    public void playShellSound()
    {
        myAS.PlayOneShot(shellCasingSound);
    }

    public void playBulletHitSound()
    {
        myAS.PlayOneShot(bulletHitSound);
    }

    public void playExplosionSound()
    {
        myAS.PlayOneShot(explosionSound);
    }

    public void playThrowSound()
    {
        myAS.PlayOneShot(throwSound);
    }

    public void playProjectileHitSound()
    {
        myAS.PlayOneShot(projectileHitSound);
    }

    public void playBrokenGlassSound()
    {
        myAS.PlayOneShot(brokenGlassSound);
    }

    public void playSawHitSound()
    {
        myAS.PlayOneShot(sawHitSound);
    }

    public void playBulletExplodeSound()
    {
        myAS.PlayOneShot(bulletExplodeSound);
    }

    public void playBulletImpactSound()
    {
        myAS.PlayOneShot(bulletImpactSound);
    }
}
