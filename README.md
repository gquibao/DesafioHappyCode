# DesafioHappyCode
Desafio de sequenciamento lógico proposto pela Happy Code

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
      - Uma variável do tipo int para armazenar os pontos do jogador.
      - Um Array de GameObjects para armazenar os objetos das estrelas da tela final (onde serão mostrados os pontos).
      - Um AudioSource
      - Dois AudioClip, um para o som de vitória e outro para o som de derrota.

    Métodos:
      - Start()
        - Inicializando a lista de GameObjects.
	- Desativar os GameObjects de todas as estrelas no array de estrelas

      - FimDaPartida()
      	- Desativar os GameObjects de todas as estrelas no array de estrelas
        - Ligando o GameObject da tela final, deixando-o visível.
        - Verificar se o jogador chegou no objetivo final.
          - Se chegou, fazer o texto da mensagem final receber uma string "SEQUÊNCIA CORRETA!" e transformar a cor da fonte em verde.
          - Se não chegou ou então o Personagem colidiu com um obstáculo, fazer o texto da mensagem final receber uma string "SEQUÊNCIA INCORRETA!" e transformar a cor da fonte em vermelho.
	  - Adiciona pontos a variável de armazenar pontos. Caso o jogador finalize a partida na quantidade mínima necessária para passar de fase, ganha 3 pontos. Caso chegue no final, porém por um trajeto mais comprido, ganha 2 pontos. Se não chegar no final, não pontua.
	  - Ativar os GameObjects das estrelas no array de estrelas, dependendo da quantidade de pontos que fez.
	  - Se o jogador vencer, atribuir o AudioClip de vitória ao AudioSource.clip, se perder, atribuir o audio de derrota.
	  - Dar play no AudioSource.

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
		- bool caso o personagem tenha colidido com algum obstáculo definido no trajeto.
		- Um AudioSource para o som de movimento do personagem.

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
			- Dar play no AudioSource.


		- OnTriggerEnter2D()
			- Verificar se a tag do objeto que colidiu é "Objetivo".
				- Se sim, o bool verificando se o jogador alcançou o objetivo recebe o valor de true.
			- Verificar se a tag do objeto que colidiu é "Obstaculo".
				- Se sim, o bool que verifica se o jogador colidiu com um obstáculo recebe o valor de true e lança a função FimDaPartida() da classe Controladora, sendo um Game Over instantâneo.

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

- Após criar as classes, monte a cena da primeira fase do jogo.
- Crie um Empty Object e adicione o componente Controladora a ele.
- Construa objetos um para cada direção que o personagem pode seguir e adicione o componente Bloco Lógico a ele. Adicione um componente Box Collider 2D a ele.
- Crie os Prefabs para os objetos que aparecerão na lista de blocos inseridos pelo jogador. Esses objetos são do tipo Button e devem ser criadas dentro de um Canvas. Insira um componente Icone Bloco Logico e, em seguida, escolha o valor da variável "ação"  do componente. Crie um evento no componente Button e arraste o componente Icone Bloco Lógico para dentro deste evento. Clique onde está escrito "No Function", selecione a classe Icone Bloco Lógico e o script OnClick(). Arraste este objeto para uma pasta Prefabs na aba Project. Agora você pode deletar o objeto da cena, pois ele está salvo como um prefab no projeto. Repita o processo para cada uma das direções que o personagem porerá se mover.
- Crie dois objetos de tipo Button dentro do Canvas, um de Play e um para limpar a lista de inputs do jogador. Crie um novo evento no componente Button e arraste o script Controladora até este novo evento. No campo No Function, selecione a classe Controladora e a função bt_Play, no caso do botão de play ou bt_Resetar no caso do botão de limpar a lista.
- Crie um objeto para ser o Personagem, insira os componentes Rigidbody2D e BoxCollider2D. No Rigidbody2D, na área Body Type, selecione Kinematic e no BoxCollider2D selecione Is Trigger e deixe ele como true.
- Crie um objeto para o Objetivo final onde o jogador deve chegar. Insira um componente BoxCollider2D nele e defina Is Trigger como true também. Em seguida, vá para a área Tag, bem no topo do Inspector e crie uma nova tag, chame-a de Objetivo e atribua essa tag ao Game Object.
- Em seguida crie um percurso que o jogador deverá fazer com objetos como Cubos, por exemplo. Posicione-os como desejar.
- Crie um novo objeto Image no Canvas e crie um objeto de texto dentro dele. Agora crie dois botões, um para reiniciar a fase e outro para voltar para o menu principal. Arraste o objeto Controladora para os eventos dentro dos botões e escolha a função bt_TentarNovamente para o botão de reiniciar a fase e o bt_VoltarMenu para o botão de retornar.
- Atribua o objeto com o texto final para a variável de texto na classe Controladora.
- Posicione 3 objetos dentro da tela final, com a arte de uma estrela e atribua os 3 ao array de GameObjects dentro da classe Controladora.
- Para a arte do jogo, pegue os assets e posicione da forma que achar melhor pelo mapa.
- Crie um GameObject com um BoxCollider2D, dê a ele a tag "Obstaculo" e posicione-o em algum local que impeça o jogador de cortar um caminho no seu level. Assim caso ele tente atravessar esse pedaço, a partida será encerrada com uma derrota.
(Recomendo que esta parte do cenário fique bem clara que seja uma área que não dá pra passar, só pra não ter risco do jogador se sentir enganado).
