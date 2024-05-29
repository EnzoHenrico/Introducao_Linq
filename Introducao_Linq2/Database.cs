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
    public class Database
    {
        private SqlConnection _conexao = new(
            "Data Source= 127.0.0.1; " +
            "Initial Catalog=DB_Penalidades; " +
            "User Id=sa; " +
            "Password=SqlServer2019!; " +
            "TrustServerCertificate=True");

        public void InsertPenalties(List<PenalidadesAplicadas> penalties)
        {
            try
            {
                _conexao.Open();

                SqlCommand cmd = new()
                {
                    CommandText = "INSERT INTO Penalidades VALUES(@RazaoSocial, @Cnpj, @NomeMotorista, @Cpf, @DataVigencia);",
                    Connection = _conexao
                };
                int current = 0;
                int total = penalties.Count;

                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                
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
                    Console.WriteLine($"Inserindo Registros: {current * 100 / total}% -- {watch.ElapsedMilliseconds/ 1000:00.00} s");
                    current++;
                }
                
                watch.Stop();
                Console.WriteLine($"Finalizado em {watch.ElapsedMilliseconds * 1000:00.000} segundos.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                _conexao.Close(); 
            }
        }
    }
}
