using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> Listar();
        
        void Cadastrar(GeneroDomain cadastrarGenero);

        /// <summary>
        /// Deletaru genero
        /// </summary>
        /// <param name="IdGenero">id do genero que sera deletado</param>
        //void Deletar(int id);

        /// <summary>
        /// atualiza um genero exitente
        /// </summary>
        /// <param name="genero">rececbe objeto genero com as informacoes que seram att</param>
        //void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// atualiza um genero existente
        /// </summary>
        /// <param name="id">id que sera atualizado</param>
        /// <param name="atualizarGenero">objeto que sera alterado</param>
        //void AtualizarIdUrl(int id, GeneroDomain atualizarGenero);

        /// <summary>
        /// busca por id
        /// </summary>
        /// <param name="id">id que sera buscado</param>
        /// <returns></returns>
        //GeneroDomain GetById(int id);
    }
}
