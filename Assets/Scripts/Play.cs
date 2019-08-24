using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private void OnMouseDown()
    {
        StartCoroutine(percorrerLista());
    }

    IEnumerator percorrerLista()
    {
        foreach(GameManager.ACAO acao in GameManager.instance.listaInput)
        {
            Personagem.instance.movimentar(acao);
            yield return new WaitForSeconds(0.5f);
        }

        GameManager.instance.fimDaPartida();
    }
}
