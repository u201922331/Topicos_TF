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
        bolsaSpacing = 0.5f;
    }

    public void AddBag() {
        if (nBolsas < 20) {
            Instantiate(bolsa, new Vector3(this.transform.position.x, this.transform.position.y + bolsaSpacing * nBolsas, this.transform.position.z), Quaternion.identity);
            nBolsas += 1;
            Debug.Log("¡Nueva bolsa!");
        }
        Debug.Log("N° de bolsas: " + nBolsas);
    }
}
