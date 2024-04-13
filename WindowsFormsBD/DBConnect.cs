using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;
using System.Collections.Generic;

namespace WindowsFormsBD
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string username;
        private string password;
        private string database;
        private string port;
        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "192.168.1.77"; //"localhost";
            database = "gestaoformandos";
            username = "programador";
            password = "Server2023!";
            port = "3306";
            string connectionString = "Server = " + server + ";Port = " + port + ";Database = " +  database + "; Uid = " + username + "; Pwd = " + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public string StatusConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection.State.ToString();
        }
        public int Count()
        {
            int count = -1;
            string query = "select count(*) from formando";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return count;
        }

        public void Insert() 
        {
            string query = "Insert into formando (nome, id_formando, morada, contacto, iban, sexo, data_nascimento) values" +
                             " ( 'Pinto da Costa', '10099', 'Rua do Porto', NULL, '000000000000000000', 'M', '1950-06-22')";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //CloseConnection();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                CloseConnection();
            }

        }

        public bool Delete() 
        {
            string query = "Delete from formando where id_formando = '10099'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool Delete(string id)
        {
            string query = "Delete from formando where id_formando = '" + id + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool Update(string id, string nome)
        {
            string query = "Update formando set nome = '"+ nome +"' where id_formando = '" + id + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public int DevolveUltimoID()
        {
            int ultimoID = 0;

            string query = "select max(id_formando) from formando";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //ultimoID = int.Parse(cmd.ExecuteScalar().ToString());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return ultimoID;
        }

        public bool Insert(string id, string nome, string morada, string contacto, string iban, char sexo, string dataNasc, int id_nacionalidade)
        {
            string query = "Insert into formando (id_formando, nome, morada, contacto, iban, sexo, data_nascimento, id_nacionalidade) values ( '" + id +"', " +
                                                            "'"+ nome +"', '"+ morada+"', '"+ contacto+"', '"+ iban + "', '"+ sexo + "', '"+ dataNasc +"', '"+ id_nacionalidade + "')";
                                                                                       
            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool PesquisaFormando(string idPesquisa, ref string nome, ref string morada, ref string contacto,
                                    ref string iban, ref char sexo, ref string dataNascimento)
        {
            bool flag = false;
            string query = "select Nome, Morada, Contacto, Iban, Sexo, Data_nascimento from formando" +
                " where id_formando = '"+ idPesquisa +"'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        nome = dataReader[0].ToString();
                        morada = dataReader["morada"].ToString();
                        contacto = dataReader[2].ToString();
                        iban = dataReader[3].ToString();
                        sexo = dataReader["sexo"].ToString()[0];
                        dataNascimento = dataReader[5].ToString();
                        flag = true;


                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                CloseConnection(); 
            }
            return flag;
        }

        public bool PesquisaFormando(string idPesquisa, ref string nome, ref string morada, ref string contacto,
                                    ref string iban, ref char sexo, ref string dataNascimento, ref string nacionalidade)
        {
            bool flag = false;
            string query = "select Nome, Morada, Contacto, Iban, Sexo, Data_nascimento, id_nacionalidade from formando" +
                " where id_formando = '" + idPesquisa + "'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        nome = dataReader[0].ToString();
                        morada = dataReader["morada"].ToString();
                        contacto = dataReader[2].ToString();
                        iban = dataReader[3].ToString();
                        sexo = dataReader["sexo"].ToString()[0];
                        dataNascimento = dataReader[5].ToString();
                        nacionalidade = dataReader[6].ToString();
                        flag = true;


                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Update(string id, string nome, string morada, string contacto, string iban, char sexo, string dataNasc, string id_nacionalidade)
        {
            string query = "Update formando set nome = '" + nome + "', morada = '" + morada + "', contacto = '" + contacto + "' , " +
                            "iban = '" + iban + "' , sexo = '" + sexo + "' , data_nascimento = '" + dataNasc + "', id_nacionalidade = '" + id_nacionalidade + "' where id_formando = '" + id + "'";
           
            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public void PreencherDataGridViewFormandos(ref DataGridView dgv)
        {
            string query = "select formando.id_formando, formando.nome, formando.iban, formando.contacto, formando.sexo, nacionalidade.nacionalidade from formando, nacionalidade " +
                "where nacionalidade.id_nacionalidade = formando.id_nacionalidade order by nome;";

            try
            {
                if(OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr[1].ToString();
                        dgv.Rows[idxLinha].Cells["Iban"].Value = dr["Iban"].ToString();
                        dgv.Rows[idxLinha].Cells["Contacto"].Value = dr["Contacto"].ToString();
                        dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr["Nacionalidade"].ToString();
                        dgv.Rows[idxLinha].Cells["Genero"].Value = dr["Sexo"].ToString();

                        idxLinha++;
                    }
                }

            } 
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /*
        public void PreencherDataGridViewFormandosPesquisa(ref DataGridView dgv, string nome, char sexo, int id_nacionalidade)
        {
            string query = "select formando.id_formando, formando.nome, formando.iban, formando.contacto, formando.sexo, nacionalidade.nacionalidade " +
                "from formando left join nacionalidade on formando.id_nacionalidade = nacionalidade.id_nacionalidade where 1 = 1 ";

  
            if (!string.IsNullOrEmpty(nome))
            {
                query += " AND nome LIKE @nome";
            }
            if (sexo != 'T')
            {
                query += " AND sexo = @sexo";
            }
            if(id_nacionalidade > 0)
            {
                query += " AND formando.id_nacionalidade = @id_nacionalidade";
            }



           query += " ORDER BY formando.nome;";

           try
           {
               if (OpenConnection())
               {
                   MySqlCommand cmd = new MySqlCommand(query, connection);
                    // Adiciona os parâmetros somente se necessário
                    cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                    cmd.Parameters.AddWithValue("@id_nacionalidade", id_nacionalidade);
                    if (sexo != 'T')
                    {
                        cmd.Parameters.AddWithValue("@sexo", sexo);
                    }


                    MySqlDataReader dr = cmd.ExecuteReader();

                   int idxLinha = 0;
                   while (dr.Read())
                   {
                       dgv.Rows.Add();
                       dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                       dgv.Rows[idxLinha].Cells["Nome"].Value = dr[1].ToString();
                       dgv.Rows[idxLinha].Cells["Iban"].Value = dr["Iban"].ToString();
                       dgv.Rows[idxLinha].Cells["Contacto"].Value = dr["Contacto"].ToString();
                       dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr["Nacionalidade"].ToString();
                       dgv.Rows[idxLinha].Cells["Genero"].Value = dr["Sexo"].ToString();
                       idxLinha++;
                   }
                   dr.Close();
               }
           }
           catch (MySqlException ex)
           {
               MessageBox.Show(ex.Message);
           }
           finally
           {
               CloseConnection();

           }
        }
        */




        
       public void PreencherDataGridViewFormandosPesquisa(ref DataGridView dgv, string nome, char sexo, string id_nacionalidade)
       {
           string query = "select id_formando, nome, iban, sexo, nacionalidade from vFormando where 1 = 1 ";


           if (!string.IsNullOrEmpty(nome))
           {
               query += " AND nome LIKE @nome";
           }
           if (sexo != 'T')
           {
               query += " AND sexo = @sexo";
           }
           if(id_nacionalidade.Length > 0)
           {
               query += " AND id_nacionalidade = @id_nacionalidade";
           }



          query += " ORDER BY nome;";

          try
          {
              if (OpenConnection())
              {
                  MySqlCommand cmd = new MySqlCommand(query, connection);
                   // Adiciona os parâmetros somente se necessário
                   cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                   cmd.Parameters.AddWithValue("@id_nacionalidade", id_nacionalidade);
                   if (sexo != 'T')
                   {
                       cmd.Parameters.AddWithValue("@sexo", sexo);
                   }


                   MySqlDataReader dr = cmd.ExecuteReader();

                  int idxLinha = 0;
                  while (dr.Read())
                  {
                      dgv.Rows.Add();
                      dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                      dgv.Rows[idxLinha].Cells["Nome"].Value = dr[1].ToString();
                      dgv.Rows[idxLinha].Cells["Iban"].Value = dr["Iban"].ToString();
                      dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr["Nacionalidade"].ToString();
                      dgv.Rows[idxLinha].Cells["Genero"].Value = dr["Sexo"].ToString();
                      idxLinha++;
                  }
                  dr.Close();
              }
          }
          catch (MySqlException ex)
          {
              MessageBox.Show(ex.Message);
          }
          finally
          {
              CloseConnection();

          }
       }
       

        public bool InsertNacionalidade(string iso2, string nacionalidade)
        {
            bool flag = true;
            // no primeiro campo é colocado 0 (zero)  para  ativação da funcionalidade de auto_increment no campo id_nacionalidade
            string query = "insert into Nacionalidade values (0, '" + iso2 + "','" + nacionalidade + "')";
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool DeleteNacionalidade(string id_nacionalidade)
        {
            bool flag = true;
            string query = "delete from Nacionalidade where id_nacionalidade = " + id_nacionalidade;
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public void PreencherComboboxNacionalidade(ref ComboBox combo)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "Nacionalidade order by nacionalidade;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        combo.Items.Add(reader[2].ToString() + " - " +
                            reader["alf2"].ToString() + " - " + reader[0].ToString());
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool PesquisaNacionalidade(string id_nacionalidade, ref string alf2, ref string nacionalidade)
        {
            bool flag = false;
            string query = "select alf2, nacionalidade from nacionalidade where id_nacionalidade = '" + id_nacionalidade + "'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        alf2 = dataReader["alf2"].ToString();
                        nacionalidade = dataReader["nacionalidade"].ToString();
                        flag = true;
                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool UpdateNacionalidade(string id_nacionalidade, string alf2, string nacionalidade)
        {
            string query = "Update nacionalidade set alf2 = '" + alf2 + "', nacionalidade = '" + nacionalidade + "' where id_nacionalidade = '"  + id_nacionalidade + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }


        public void PreencherDataGridViewNacionalidade(ref DataGridView dgv)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from nacionalidade order by nacionalidade";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["ALF2"].Value = dr[1].ToString();
                        dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr[2].ToString();
               
                        idxLinha++;
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public string DevolverNacionalidade(string id_nacionalidade)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "Nacionalidade where id_nacionalidade = " + id_nacionalidade;

            string nacionalidade = "";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        nacionalidade = reader[2].ToString() + " - " +
                            reader["alf2"].ToString() + " - " + reader[0].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return nacionalidade;
        }

        public bool ValidateUsers(string username, string password, ref string id_user) 
        { 
            bool flag = false;

            try
            {
                string query = "select username from users where binary username = '" + username + "' " +
                    "and pwd = " + "sha2('" + password + "', 512) ";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    if(cmd.ExecuteScalar() != null)
                    {
                        id_user = cmd.ExecuteScalar().ToString();
                        flag = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }


        public bool ValidateUsers2(string username, string password, ref string id_user)
        {
            bool flag = false;

            try
            {
                string query = "select id_utilizador from utilizador where binary nome_utilizador = '" + username + "' " +
                    "and palavra_passe = " + "sha2('" + password + "', 512) and estado = 'A';";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        id_user = cmd.ExecuteScalar().ToString();
                        flag = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
                if(flag)
                {
                    PUserSuccessLogin(username, "S");
                }
                else
                {
                    PUserSuccessLogin(username, "U");
                }
            }

            return flag;
        }

        private void PUserSuccessLogin(string username, string result)
        {
            try
            {
                string query = "call pUSuccesLogin('" + username+ "', '" + result + "')";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        public bool ValidateUsersStatus(string username)
        {
            bool flag = false;

            try
            {
                string query = "select id_utilizador from utilizador where nome_utilizador = '" + username + "' " +
                    "and estado = 'I';";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        flag = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool ValidateUsersStatus(string username, ref int nfalhas)
        {
            bool flag = false;

            try
            {
                string query = "select falhas from utilizador where nome_utilizador = '" + username + "' " +
                    "and estado = 'I';";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    if (cmd.ExecuteScalar() != null)
                    {
                        nfalhas = int.Parse(cmd.ExecuteScalar().ToString());
                        flag = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool InsertArea(string id, string area)
        {
            string query = "Insert into area (id_area, area) values ( '" + id + "', '" + area + "')";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }


        public int DevolveUltimoIDArea()
        {
            int ultimoID = 0;

            string query = "select max(id_area) from area";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //ultimoID = int.Parse(cmd.ExecuteScalar().ToString());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return ultimoID;
        }

        public void PreencherComboboxArea(ref ComboBox combo)
        {
            string query = "select id_area, area from area order by area;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        combo.Items.Add(reader[0].ToString() + " - " + reader["area"].ToString());
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        public bool UpdateArea(string id_area, string area)
        {
            string query = "Update area set area = '" + area + "' where id_area = '" + id_area + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool PesquisaArea(string id_area, ref string area)
        {
            bool flag = false;
            string query = "select area from area where id_area = '" + id_area + "'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        area = dataReader["area"].ToString();
                        flag = true;
                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool DeleteArea(string id_area)
        {
            bool flag = true;
            string query = "delete from area where id_area = " + id_area;
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public void PreencherdataGridViewArea(ref DataGridView dgv)
        {
            string query = "select id_area, area from area order by area";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Area"].Value = dr[1].ToString();

                        idxLinha++;
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DevolveUltimoIDFormador()
        {
            int ultimoID = 0;

            string query = "select max(id_formador) from formador";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //ultimoID = int.Parse(cmd.ExecuteScalar().ToString());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return ultimoID;
        }

        public bool InsertFormador (string id, string nome, string nif, string dataNasc, int id_area)
        {
            string query = "Insert into formador (id_formador, nome, nif, dataNascimento, id_area) values ( '" + id + "', " +
                                                            "'" + nome + "', '" + nif + "', '" + dataNasc + "', '" + id_area + "')";
            
            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool PesquisaFormador(string idPesquisa, ref string nome, ref string nif, ref string dataNascimento, ref string area)
        {
            bool flag = false;
            string query = "select Nome, Nif, dataNascimento, id_area from formador" +
                " where id_formador = '" + idPesquisa + "'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        nome = dataReader[0].ToString();
                        nif = dataReader[1].ToString();
                        dataNascimento = dataReader[2].ToString();
                        area = dataReader[3].ToString();
                        flag = true;


                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public string DevolverArea(string id_area)
        {
            string query = "select id_area, area from area where id_area = " + id_area;

            string area = "";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        area = reader[0].ToString() + " - " + reader["area"].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return area;
        }

        public bool UpdateFormador(string id, string nome, string nif, string dataNasc, string id_area)
        {
            string query = "Update formador set nome = '" + nome + "', nif = '" + nif + "', dataNascimento = '" + dataNasc + "', id_area = '" + id_area + "' where id_formador = '" + id + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }

        public bool DeleteFormador(string id)
        {
            string query = "Delete from formador where id_formador = '" + id + "'";

            bool flag = true;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            finally
            {
                CloseConnection();
            }

            return flag;
        }


        public void PreencherDataGridViewFormadoresPesquisa(ref DataGridView dgv, string nome, string id_area)
        {
            string query = "select id_formador, nome, nif, area from viewFormador where 1 = 1 ";


            if (!string.IsNullOrEmpty(nome))
            {
                query += " AND nome LIKE @nome";
            }
            
            if (id_area.Length > 0)
            {
                query += " AND id_area = @id_area";
            }


            query += " ORDER BY nome;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    // Adiciona os parâmetros somente se necessário
                    cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                    cmd.Parameters.AddWithValue("@id_area", id_area);
                   


                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr[1].ToString();
                        dgv.Rows[idxLinha].Cells["Nif"].Value = dr["Nif"].ToString();
                        dgv.Rows[idxLinha].Cells["Area"].Value = dr["Area"].ToString();
                        idxLinha++;
                    }
                    dr.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();

            }
        }



    }
}


