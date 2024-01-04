using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Effectmanager;
    private AudioSource _SFXaudioSource;
    private AudioSource _BGMaudioSource;
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
        _BGMaudioSource = _camera.GetComponent<AudioSource>();
        _SFXaudioSource = Effectmanager.GetComponent<AudioSource>();
    }

    public void BGMTogleBtn()
    {
        _BGMaudioSource.enabled = !_BGMaudioSource.enabled;
    }

    public void SFXTogleBtn()
    {
        
    }


    // Start is called before the first frame update
    public void StrawberryBtn()
    {
        Player.Instance.GetResource(Resources.RESOURCE1, 0);
    }



}
