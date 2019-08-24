using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public static Personagem instance;
    public Vector3 posicaoInicial;
    public bool objetivoAlcancado;

    private void Awake()
    {
        instance = this;
        posicaoInicial = transform.position;
    }

    public void movimentar(GameManager.ACAO acao)
    {
        int x = 0;
        int y = 0;

        switch(acao)
        {
            case GameManager.ACAO.CIMA:
                y = 1;
                break;

            case GameManager.ACAO.BAIXO:
                y = -1;
                break;

            case GameManager.ACAO.ESQUERDA:
                x = -1;
                break;

            case GameManager.ACAO.DIREITA:
                x = 1;
                break;
        }

        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objetivo")
        {
            objetivoAlcancado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Objetivo")
        {
            objetivoAlcancado = false;
        }
    }
}
