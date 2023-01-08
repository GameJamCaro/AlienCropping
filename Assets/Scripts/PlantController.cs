using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public GameObject plant;

    private void Start()
    {
        plant.SetActive(false);
        StartCoroutine(WaitAndGrow());
    }

    IEnumerator WaitAndGrow()
    {
        yield return new WaitForSeconds(5);
        plant.SetActive(true);
    }
}
