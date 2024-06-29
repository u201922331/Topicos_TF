using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolsaStack : MonoBehaviour
{
    [SerializeField]
    private GameObject bolsa;
    private int nBolsas;
    private float bolsaSpacing;

    void Awake() {
        nBolsas = 0;
        bolsaSpacing = 0.25f;
    }

    public void AddBag() {
        if (nBolsas < 20) {
            Instantiate(bolsa, new Vector3(this.transform.position.x, this.transform.position.y + bolsaSpacing * nBolsas, this.transform.position.z), Quaternion.identity);
            nBolsas += 1;
            // Debug.Log("¡Nueva bolsa!");
        }
        Debug.Log("N° de bolsas: " + nBolsas);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Jugador detectado...");
            PenguinMovement pinguino = collision.GetComponent<PenguinMovement>();
            for (int i = 0; i < pinguino._sacosCount; i++)
                AddBag();
            pinguino.ResetearSacos();
        }
        Debug.Log("¿?");
    }
}
