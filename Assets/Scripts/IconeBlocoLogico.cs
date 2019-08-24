using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconeBlocoLogico : MonoBehaviour
{
    public GameManager.ACAO acao;

    public void OnClick()
    {
        GameManager.instance.listaInput.Remove(gameObject);
        Destroy(gameObject);
    }
}
