using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoLogico : MonoBehaviour
{
    public GameObject iconeBloco;
    public Vector3 posicaoInicial;
    public bool colidiuAreaBlocos;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    public void OnMouseDrag()
    {
        if(GameManager.instance.canvasGroupBlocos.blocksRaycasts)
            transform.localPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
    }

    public void OnMouseUp()
    {
        if (colidiuAreaBlocos)
        {
            GameObject go = Instantiate(iconeBloco, GameManager.instance.areaBlocos);
            GameManager.instance.listaInput.Add(go);
        }
        transform.position = posicaoInicial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colidiuAreaBlocos = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colidiuAreaBlocos = false;
    }
}
