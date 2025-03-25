# Criptografia de Matriz

## Descrição

Este projeto implementa um sistema de criptografia e descriptografia baseado em matrizes. A matriz de entrada é transformada por meio de uma chave de criptografia 2x2, permitindo a conversão de mensagens em sequências numéricas e vice-versa.

## Funcionalidades

- Criptografia de matrizes com base em uma chave fornecida pelo usuário.
- Descriptografia de matrizes previamente codificadas.
- Conversão de matrizes criptografadas em mensagens legíveis.

## Estrutura do Projeto

### `Matriz.cs`

Este arquivo implementa a classe `Matriz`, que contém:

- **Construtores**:
  - Inicializa matrizes para criptografia e descriptografia.
- **Métodos principais**:
  - `Criptografar()`: Aplica a transformação baseada na chave.
  - `Descriptografar()`: Recupera os valores originais a partir da matriz criptografada.
  - `ObterFrase()`: Converte os valores da matriz em texto legível.
  - `SetChave()`, `SetMatriz()`, `SetMatrizCriptografada()`: Configura as matrizes utilizadas no processo.

### `Program.cs`

Este arquivo contém a lógica principal do programa:

- Permite ao usuário escolher entre criptografar ou descriptografar uma matriz.
- Solicita ao usuário a chave de criptografia e os valores da matriz.
- Exibe os resultados da operação escolhida.