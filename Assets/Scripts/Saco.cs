using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saco : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb;
    bool _doDamage;
    public void Initialize(Vector2 startPosition, Vector2 startVelocity, SacoSO sacoSO)
    {
        transform.position = startPosition;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = startVelocity;
        _spriteRenderer.sprite = sacoSO.SacoSprite;
        _doDamage = sacoSO.DoDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            return;
        }

        if(collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            return;
        }
        
    }
}
