using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Transform cam;
    [SerializeField] private AudioClip gunshot;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 60f;

    AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Awake() {
        cam = Camera.main.transform;
    }

    public void Shoot(){
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(gunshot);
            StartCoroutine(wait());
        }
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, range)){
            if(hit.collider.GetComponent<ZombieManager>() != null){
                hit.collider.GetComponent<ZombieManager>().GetHit(damage, hit.point, hit.normal);
            }
        }
    }

    public IEnumerator wait(){
        yield return new WaitForSeconds(0.45f);
        audioSource.Stop();
    }
}