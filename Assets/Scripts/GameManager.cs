using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum ACAO { CIMA, BAIXO, ESQUERDA, DIREITA }

    public CanvasGroup canvasGroupBlocos;

    public Transform areaBlocos;

    public GameObject telaFinal;
    public GameObject[] estrelas;

    public TextMeshProUGUI mensagemFinal;

    public List<GameObject> listaInput;

    public int movimentosMinimosFase;
    private int pontos;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        listaInput = new List<GameObject>();
        telaFinal.SetActive(false);
    }

    public void fimDaPartida()
    {
        StopAllCoroutines();
        telaFinal.SetActive(true);

        if (Personagem.instance.objetivoAlcancado)
        {
            mensagemFinal.text = "SEQUÊNCIA CORRETA!";
            if (listaInput.Count <= movimentosMinimosFase)
            {
                pontos = 3;
            }

            else
            {
                pontos = 2;
            }
            mensagemFinal.color = Color.green;
        }

        else
        {
            mensagemFinal.text = "SEQUÊNCIA INCORRETA!";
            pontos = 0;
            mensagemFinal.color = Color.red;
        }


        for(int i = 0; i < pontos; i++)
        {
            estrelas[i].SetActive(true);
        }
    }

    public void bt_Resetar()
    {
        foreach (GameObject go in listaInput)
        {
            Destroy(go);
        }
        listaInput.Clear();
    }

    public void bt_Play()
    {
        canvasGroupBlocos.blocksRaycasts = false;
        StartCoroutine(percorrerLista());
    }

    IEnumerator percorrerLista()
    {
        foreach (GameObject go in listaInput)
        {
            Personagem.instance.movimentar(go.GetComponent<IconeBlocoLogico>().acao);
            yield return new WaitForSeconds(0.5f);
        }
        fimDaPartida();
    }

    public void bt_TentarNovamente()
    {
        telaFinal.SetActive(false);
        Personagem.instance.transform.position = Personagem.instance.posicaoInicial;
        canvasGroupBlocos.blocksRaycasts = true;
    }

    public void bt_VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void bt_ProximaFase()
    {
        SceneManager.LoadScene("Fase 2");
    }
}
