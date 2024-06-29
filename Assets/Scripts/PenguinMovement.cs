using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public static PenguinMovement instance;
    [SerializeField] List<Sprite> _penguinSacos;
    [SerializeField] Sprite _pinguinoMuerto;
    SpriteRenderer _spriteRenderer;
    int _sacosCount = 0;
    bool _isAlive = true;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (!_isAlive) return;

       Vector3 mousePosition = 
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
       mousePosition.y = transform.position.y;
       mousePosition.z = transform.position.y;
       mousePosition.x = Mathf.Clamp(mousePosition.x,
       -Camera.main.orthographicSize,
       Camera.main.orthographicSize);
       transform.position = mousePosition;

    }

    public void AgregarSaco()
    {
        if (!_isAlive) return;

        ++_sacosCount;
        _spriteRenderer.sprite = _penguinSacos[_sacosCount];
        if (_sacosCount == 5) _isAlive = false;

    }
    public void ResetearSacos()
    {
        _sacosCount = 0;
        _spriteRenderer.sprite = _penguinSacos[_sacosCount];
    }

    public void MatarPinguino()
    {
        if (!_isAlive) return;

        _spriteRenderer.sprite = _pinguinoMuerto;
        _isAlive = false;
    }
}