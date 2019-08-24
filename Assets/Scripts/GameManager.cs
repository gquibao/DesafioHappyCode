using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum ACAO {  CIMA, BAIXO, ESQUERDA, DIREITA}
   
    public Transform areaBlocos;

    public List<GameObject> listaInput;
    public List<ACAO> caminhoCorreto;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        listaInput = new List<GameObject>();
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
        StartCoroutine(percorrerLista());
    }

    IEnumerator percorrerLista()
    {
        foreach (GameObject go in GameManager.instance.listaInput)
        {
            Personagem.instance.movimentar(go.GetComponent<IconeBlocoLogico>().acao);
            yield return new WaitForSeconds(0.5f);
        }

        GameManager.instance.fimDaPartida();
    }
}
