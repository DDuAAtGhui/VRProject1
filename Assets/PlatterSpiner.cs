using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class PlatterSpiner : MonoBehaviour
{
    AudioSource recrodAudioSource;
    [SerializeField] float spinSpeed = 1f;
    [SerializeField] XRSocketInteractor socketInteractor;
    [SerializeField] InteractionLayerMask interactionLayerMask;
    IXRSelectInteractable selected;
    void Start()
    {
    }

    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        if (recrodAudioSource != null)
            if (recrodAudioSource.isPlaying)
                transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            else
                transform.Rotate(Vector3.zero);
    }
    public void OnSocketSelect()
    {
        selected = socketInteractor.GetOldestInteractableSelected();
        GameObject go = selected.transform.gameObject;
        recrodAudioSource = go.GetComponent<AudioSource>();

        if (recrodAudioSource == null)
            return;

        recrodAudioSource.Play();
        recrodAudioSource.loop = true;
    }
    public void OnSocketExit()
    {
        if (recrodAudioSource == null)
            return;
        recrodAudioSource.Stop();
    }

    private void OnDrawGizmos()
    {

    }
}
