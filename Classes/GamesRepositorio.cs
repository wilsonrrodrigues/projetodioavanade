using System;
using System.Collections.Generic;
using DIO.Games.Interfaces;

namespace DIO.Games
{
  public class GamesRepositorio : IRepositorio<Games>
  {
    private List<Games> listaGames = new List<Games>();  
    public void Atualiza(int id, Games objeto)
    {
      listaGames[id] = objeto;
    }

    public void Exclui(int id)
    {
      listaGames[id].Excluir();
    }

    public void Insere(Games objeto)
    {
      listaGames.Add(objeto);
    }

    public List<Games> Lista()
    {
      return listaGames;
    }

    public int ProximoId()
    {
      return listaGames.Count;
    }

    public Games RetornaPorId(int id)
    {
      return listaGames[id];
    }
  }
}