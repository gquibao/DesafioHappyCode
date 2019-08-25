# DesafioHappyCode
Desafio de sequenciamento logico proposto pela Happy Code

 ----- Passo a passo -----

- Crie um novo projeto no Unity.
- Crie uma nova cena para a fase.
- Crie uma classe que controle as funcionalidades da cena como o loop do jogo, a interface, pontuação, a sequência de blocos lógicos colocados pelo usuário, etc.

--------------------------------------  Controladora ----------------------------------------------------------------------   
    
    Atributos:
      - Um enum com as possíveis direções que o jogador pode ir (esquerda, direita, cima e baixo).
      - Um Transform que será o objeto "pai" da lista de blocos inseridos pelo usuário, ou seja, onde eles irão aparecer. 
      - Um Text ou TextMeshProUGUI para mostrar a mensagem final (Percurso Correto ou Incorreto).
      - Um GameObject para salvar o objeto da tela final. Ele vai fazer com que a mensagem final apareça ou desapareça no decorrer da partida.
      - Uma lista que guarde GameObjects que será a lista de blocos inseridos pelo jogador.

    Métodos:
      - Start()
        - Inicializando a lista de GameObjects.

      - FimDaPartida()
        - Ligando o GameObject da tela final, deixando-o visível.
        - Verificar se o jogador chegou no objetivo final.
          - Se chegou, fazer o texto da mensagem final receber uma string "SEQUÊNCIA CORRETA!" e transformar a cor da fonte em verde.
          - Se não chegou, fazer o texto da mensagem final receber uma string "SEQUÊNCIA INCORRETA!" e transformar a cor da fonte em vermelho.

      - bt_Resetar()
        - Deletar os GameObjects com as direções inseridas pelo jogador.
        - Limpar a lista ( List<>.Clear() ou List<> = new List<>)

      - bt_Play()
        - Chamar a Corotina "PercorrerLista".

      - PercorrerLista()
        - Percorrer toda a lista de blocos inseridos pelo jogador.
        - Mandar o valor do enum com a direção como parâmetro para a função Movimentar() da classe Personagem.
        - Chamar a função FimDaPartida().

      - bt_TentarNovamente()
        - Desabilitar a tela final.
        - Resetar a posição do personagem, colocando ele de volta na posição inicial da fase.

      - bt_VoltarMenu()
        - Carregar a cena do menu.
        
--------------------------------------------------------------------------------------------------------------------------

- Crie uma Classe para o bloco lógico que será selecionado.


-------------------------------------- Bloco Lógico ----------------------------------------------------------------------

	  Atributos:
	    - Um GameObject para o Prefab do objeto que será instanciado na interface.
	    - Um Vector3 guardando a posição inicial do bloco.
	    - um bool para verificar se o objeto colidiu com o a área de fixar os blocos.

	  Métodos:
	    - Start()
	      - Vector3 receber a posição inicial do objeto.

	    - OnMouseDrag()
	      - Fazer a posição do objeto receber a posição do cursor.

	    - OnMouseUp()
	      - Se o bool tiver valor true, instanciar o GameObject do prefab na posição definida como área para os blocos na classe Controladora.
	      - Adicionar o novo objeto instanciado na lista localizada na classe Controladora.

	    - OnTriggerEnter2D()
	      - Fazer bool receber o valor true.

	    - OnTriggerExit2D()
	      - Fazer bool recer o valor false.

--------------------------------------------------------------------------------------------------------------------------

- Crie uma classe para o Personagem.

-------------------------------------- Personagem ------------------------------------------------------------------------

	Atributos:
		- Vector3 guardando a posição inicial do personagem.
		- bool se o jogador alcançou o objetivo.

	Métodos:

		- Start()
			- Vector3 receber a posição inicial do persoangem.

		- Movimentar(enum com as direções localizado na classe Controladora)
			- Criar duas variáveis locais do tipo int, uma x e uma y.
			- Criar um switch case usando o enum recebido como parâmetro dessa função:
				- Se enum = ESQUERDA, fazer a variável local x receber o valor - 1.
				- Se enum = DIREITA, fazer a variável local x receber o valor + 1.
				- Se enum = BAIXO, fazer a variável local y receber o valor - 1.
				- Se enum = CIMA, fazer a variável local y receber o valor + 1.
			- Transform.position do personagem receber um novo Vector2 com sua posição atual no eixo X somando o valor da variável local X e no eixo Y somando a variável local Y.


		- OnTriggerEnter2D()
			- Verificar se a tag do objeto que colidiu é "Objetivo".
				- Se sim, o bool verificando se o jogador alcançou o objetivo recebe o valor de true.

		- OnTriggerExit2D()
			- Verificar se a tag do objeto que deixou de colidir é "Objetivo".
				- Se sim, o bool verificando se o jogador alcançou o objetivo recebe o valor de false.

-------------------------------------------------------------------------------------------------------------------------

- Crie uma classe para o objeto que será mostrado na lista de blocos selecionados pelo usuário.

-------------------------------------- Ícone Bloco ------------------------------------------------------------------------
	
	Atributos:
		- Uma variável recebendo um valor do enum localizado na classe Controladora.
		

	Métodos:
		- OnClick()
			- Remover este objeto da lista na classe Controladora.
			- Destruir o objeto em que o script está aplicado.

---------------------------------------------------------------------------------------------------------------------------
