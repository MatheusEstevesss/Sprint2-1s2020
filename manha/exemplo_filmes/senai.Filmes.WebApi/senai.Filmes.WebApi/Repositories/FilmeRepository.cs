using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        private string StringConexao = "Data Source=DEV12\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa@132;";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "SELECT Filmes.IdFilme, Filmes.Titulo, Filmes.IdGenero, Generos.Nome FROM Filmes INNER JOIN Generos ON Filmes.IdGenero = Generos.IdGenero ORDER BY Titulo DESC";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        //Cria um objeto genero do tipo GeneroDomain
                        FilmeDomain Filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr[1].ToString(),

                            IdGenero = Convert.ToInt32(rdr[2]),

                            Genero = new GeneroDomain {
                                IdGenero = Convert.ToInt32(rdr[2]),
                                Nome = rdr[3].ToString()
                            }  
                        };                        
                        // Adiciona o genero criado à tabela generos
                        filmes.Add(Filme);
                    }
                }
            }
            return filmes;
        }
        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filmes (Titulo,IdGenero) VALUES (@Titulo,@IdGenero)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr[1].ToString(),

                            IdGenero = Convert.ToInt32(rdr[2])
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filmes SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain GetByName(string Name)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetByName = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE Titulo = @Name";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetByName, con))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr[1].ToString(),

                            IdGenero = Convert.ToInt32(rdr[2])
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }
    }
}