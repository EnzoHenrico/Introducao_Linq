using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace Introducao_Linq2
{
    public class ManageSql
    {
        private SqlConnection _conexao = new(
            "Data Source= 127.0.0.1; " +
            "Initial Catalog=DB_Penalidades; " +
            "User Id=sa; " +
            "Password=SqlServer2019!; " +
            "TrustServerCertificate=True");

        public void ProcessDataToMongo()
        {
            // Fetch queries
            var query = GetPenalties();
            var registerDescription = "Inserção de dados do SQL para o MongoDB";
            var registersCount = query.Count;
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                // Load to mongo
                var mongo = new ManageMongo();
                mongo.InsertPenalties(query);

                // Save process log
                _conexao.Open();

                var cmd = new SqlCommand
                {
                    Connection = _conexao,
                    CommandText = "INSERT INTO Controle_Processamento VALUES(@Descricao, @Data_Execucao, @Numero_de_Registros);"
                };

                cmd.Parameters.Add(new SqlParameter("@Descricao", registerDescription));
                cmd.Parameters.Add(new SqlParameter("@Data_Execucao", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@Numero_de_Registros", registersCount));
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _conexao.Close();
                watch.Stop();
                Console.WriteLine($"Finalizado com sucesso a tranferência dos dados {watch.ElapsedMilliseconds / 1000:00.000} segundos.");
                Console.WriteLine("\n - Pressione qualquer tecla para voltar - \n");
                Console.ReadKey();
            }
        }

        public void InsertPenalties(List<PenalidadesAplicadas> penalties)
        {
            try
            {
                _conexao.Open();

                var cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO Penalidades VALUES(@RazaoSocial, @Cnpj, @NomeMotorista, @Cpf, @DataVigencia);",
                    Connection = _conexao
                };
                int current = 0;
                int total = penalties.Count;

                var watch = System.Diagnostics.Stopwatch.StartNew();
                
                foreach (var penalidade in penalties)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@RazaoSocial", penalidade.RazaoSocial));
                    cmd.Parameters.Add(new SqlParameter("@Cnpj", penalidade.Cnpj));
                    cmd.Parameters.Add(new SqlParameter("@NomeMotorista", penalidade.NomeMotorista));
                    cmd.Parameters.Add(new SqlParameter("@Cpf", penalidade.Cpf));
                    cmd.Parameters.Add(new SqlParameter("@DataVigencia", penalidade.VigenciaCadastro));

                    cmd.ExecuteNonQuery();

                    Console.Clear();
                    Console.WriteLine($"Inserindo Registros: {current * 100 / total}% -- {watch.ElapsedMilliseconds / 1000:00.00} s");
                    current++;
                }
                watch.Stop();
                Console.WriteLine($"Finalizado com sucesso em {watch.ElapsedMilliseconds / 1000:00.00} segundos.");
                Console.WriteLine("\n - Pressione qualquer tecla para voltar - \n");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                _conexao.Close(); 
            }
        }

        private List<PenalidadesAplicadas> GetPenalties()
        {
            var queryResult = new List<PenalidadesAplicadas>();
            try
            {
                _conexao.Open();
                var cmd = new SqlCommand
                {
                    Connection = _conexao,
                    CommandText = "SELECT * FROM Penalidades"
                };

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        queryResult.Add(new PenalidadesAplicadas
                        {
                            RazaoSocial = reader.GetString(1),
                            Cnpj = reader.GetString(2),
                            NomeMotorista = reader.GetString(3),
                            Cpf = reader.GetString(4),
                            VigenciaCadastro = reader.GetDateTime(5)

                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _conexao.Close();
            }
            return queryResult;
        }
    }
}
