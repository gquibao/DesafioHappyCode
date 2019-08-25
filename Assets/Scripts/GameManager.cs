using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum ACAO {  CIMA, BAIXO, ESQUERDA, DIREITA}

    public CanvasGroup canvasGroupBlocos;
   
    public Transform areaBlocos;

    public GameObject telaFinal;

    public TextMeshProUGUI mensagemFinal;

    public List<GameObject> listaInput;
    public List<ACAO> caminhoCorreto;

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
        telaFinal.SetActive(true);

        if (Personagem.instance.objetivoAlcancado)
        {
            mensagemFinal.text = "SEQUÊNCIA CORRETA!";
            mensagemFinal.color = Color.green;
        }

        else
        {
            mensagemFinal.text = "SEQUÊNCIA INCORRETA!";
            mensagemFinal.color = Color.red;
        }
    }

    public void bt_Resetar()
    {
        foreach(GameObject go in listaInput)
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
        foreach (GameObject go in GameManager.instance.listaInput)
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
}
