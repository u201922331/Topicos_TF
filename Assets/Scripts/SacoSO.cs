using UnityEngine;

[CreateAssetMenu(fileName ="Saco", menuName ="Bean/Saco")]
public class SacoSO : ScriptableObject
{
    [SerializeField] Sprite _sacoSprite;
    [SerializeField] bool _doDamage;
    [SerializeField] float _colliderRadius;
    public Sprite SacoSprite => _sacoSprite;
    public bool DoDamage => _doDamage;
    public float ColliderRadius => _colliderRadius;
}
