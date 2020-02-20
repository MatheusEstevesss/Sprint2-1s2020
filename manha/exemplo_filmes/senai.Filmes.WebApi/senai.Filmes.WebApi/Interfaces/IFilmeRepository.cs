using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();

        void Cadastrar(FilmeDomain filme);

        FilmeDomain GetById(int id);

        FilmeDomain GetByName(string Name);

        void Deletar(int id);

        void Atualizar(int id, FilmeDomain filme);
    }
}
