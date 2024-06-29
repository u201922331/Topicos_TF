using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolsaStack : MonoBehaviour
{
    public static BolsaStack Instance { get;private set; }

    [SerializeField] private GameObject bolsa;
    [SerializeField] private GameObject mouseAviso;
    private List<GameObject> stack = new List<GameObject>();
    private float bolsaSpacing;
    private bool _inArea;

    void Awake() {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        bolsaSpacing = 0.25f;
    }

    public void ResetStack()
    {
        foreach(var bolsa in stack)
        {
            Destroy(bolsa);
        }
        stack.Clear();
    }

    public void AddBag() {
        GameObject Bolsa = Instantiate(bolsa, new Vector3(this.transform.position.x, this.transform.position.y + bolsaSpacing * stack.Count, this.transform.position.z), Quaternion.identity);
        stack.Add(Bolsa);
        GameManager.Instance.AddScore(3);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _inArea && PenguinMovement.instance.CanLeaveSacos)
        {
            for (int i = 0; i < PenguinMovement.instance._sacosCount; i++)AddBag();
            PenguinMovement.instance.ResetearSacos();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _inArea = true;

            if(PenguinMovement.instance.CanLeaveSacos) mouseAviso.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _inArea = false;
            mouseAviso.SetActive(false);
        }
    }
}
