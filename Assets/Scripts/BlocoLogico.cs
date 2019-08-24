using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoLogico : MonoBehaviour
{
    public GameObject iconeBloco;
    public Vector3 posicaoInicial;
    public bool hasCollided;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    public void OnMouseDown()
    {
        Debug.Log("Pegou");
    }

    public void OnMouseDrag()
    {
        Debug.Log("Segurando");
        transform.localPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
    }

    public void OnMouseUp()
    {
        Debug.Log("Soltou");
        if (hasCollided)
        {
            GameObject go = Instantiate(iconeBloco, GameManager.instance.areaBlocos);
            GameManager.instance.listaInput.Add(go);
            /*Transform posicaoBloco = GameManager.instance.posicaoBloco;
            go.transform.position = new Vector2(posicaoBloco.position.x + GameManager.instance.listaInput.Count - 1, posicaoBloco.position.y);*/
        }
        transform.position = posicaoInicial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasCollided = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
    }
}
