using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public static PenguinMovement instance;
    [SerializeField] List<Sprite> _penguinSacos;
    [SerializeField] Sprite _pinguinoMuerto;
    SpriteRenderer _spriteRenderer;
    public int _sacosCount = 0;
    bool _isAlive = true;

    public bool CanLeaveSacos => _sacosCount > 0 && _isAlive;

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

    public void RevivirPinguino()
    {
        _isAlive = true;
        _sacosCount = 0;
        _spriteRenderer.sprite = _penguinSacos[0];
    }

    public void AgregarSaco()
    {
        if (!_isAlive) return;

        ++_sacosCount;
        _spriteRenderer.sprite = _penguinSacos[_sacosCount];

        if (_sacosCount == 5) MatarPinguino();
        else GameManager.Instance.AddScore(2);
    }

    public void ResetearSacos()
    {
        _sacosCount = 0;
        _spriteRenderer.sprite = _penguinSacos[_sacosCount];
    }

    public void YunquePinguino()
    {
        if (!_isAlive) return;

        _spriteRenderer.sprite = _pinguinoMuerto;

        MatarPinguino();
    }

    public void MatarPinguino()
    {
        _sacosCount = 0;
        _isAlive = false;
        GameManager.Instance.EndGame();
    }
}