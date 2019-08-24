using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum ACAO {  CIMA, BAIXO, ESQUERDA, DIREITA}

    public Transform posicaoBloco;

    public List<ACAO> listaInput;
    public List<ACAO> caminhoCorreto;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        listaInput = new List<ACAO>();
    }

    public void fimDaPartida()
    {
        if(Personagem.instance.objetivoAlcancado)
        {
            Debug.Log("Fim");
            Debug.Log(listaInput.Count);
        }

        else
        {
            StartCoroutine(reiniciarLevel());
        }
    }

    IEnumerator reiniciarLevel()
    {
        yield return new WaitForSeconds(1);
        Personagem.instance.transform.position = Personagem.instance.posicaoInicial;
    }
}
