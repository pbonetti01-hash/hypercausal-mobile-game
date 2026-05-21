<img width="689" height="337" alt="Captura de tela 2026-05-21 114040" src="https://github.com/user-attachments/assets/0baa25ac-cfe7-4512-afd9-70c4b5e9df4f" />

# 🪐 Core Defender - Core Loop Demo

**Ball Defender** é um jogo mobile *hypercasual* de sobrevivência minimalista ambientado em Marte. O objetivo é gerenciar escudos orbitais para proteger o núcleo de uma fábrica contra disparos constantes vindos de direções cardinais, tentando resistir pelo maior tempo possível.

Este repositório contém a demonstração do **Core Loop (mecanismo principal de jogabilidade)** do projeto.

## 🕹️ Mecânicas Principais

* **Direção dos Disparos:** Os tiros surgem de quatro pontos fixos e bem definidos: **Cima, Baixo, Direita e Esquerda**, movendo-se em linha reta em direção ao núcleo central.
* **Sistema de Vida Única:** O núcleo possui apenas **1 de Vida**. Qualquer impacto de tiro resulta em *Game Over* imediato.
* **Mecânica de Risco (Cura):** Itens de cura surgem dinamicamente. O escudo **bloqueia e destrói** a cura se entrar em contato com ela. Para coletar o item, o jogador deve remover o escudo daquela trajetória e permitir que o núcleo absorva a cura, ficando temporariamente exposto a riscos.
* **Objetivo:** Não há pontuação por itens ou eliminação. O único objetivo é a **sobrevivência por tempo** (cronômetro).
* **Ciclo Dia e Noite:** O ambiente passa por transições visuais de iluminação para simular o ciclo de tempo no planeta Marte durante a partida.

<img width="620" height="349" alt="Captura de tela 2026-05-21 110035" src="https://github.com/user-attachments/assets/d0e0d431-7397-4005-a957-505c661ad0c3" />

## 📱 Controles (Mobile / Simulação)

* **Touch / Mouse:** Deslize o dedo ou clique e arraste para orbitar e rotacionar os escudos ao redor do núcleo central, alternando rapidamente entre as frentes de defesa.

## 🛠️ Requisitos Técnicos

* **Engine:** Unity (Desenvolvido com foco em plataformas Mobile Android).
* **Input:** Configurado para detecção de arrasto por toque na tela.
* **Renderização:** Transição de cores em tempo de execução para o efeito do ciclo dia/noite.

<img width="706" height="343" alt="Captura de tela 2026-05-21 105557" src="https://github.com/user-attachments/assets/99d03c6c-96db-4115-983b-279ce426557c" />
