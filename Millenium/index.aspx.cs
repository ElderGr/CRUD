using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Millenium
{
	public partial class WebForm1 : System.Web.UI.Page
	{

		private MySqlConnection conexao = new MySqlConnection();
		private MySqlCommand comando = new MySqlCommand();
		private MySqlDataReader leitor;

		public void Page_Load(object sender, EventArgs e)
		{
			try
			{
				conexao.ConnectionString = "server=remotemysql.com;Database=xJv40UDNty;Uid=xJv40UDNty;PWD=jVCgdn8byE;Port=3306";
				conexao.Open();
			}

			catch (Exception Erro)
			{
				
			}

			string query = "select u.Id_usuario id_usuario, u.Nome_usuario nome, u.Email_usuario email, e.Logradouro logradouro, e.Complemento comp, e.Bairro bairro,e.CEP cep,c.Nome_cidade cidade,e.Numero numero from Endereco e " +
				"Inner join Usuario u on e.Usuario_Id_usuario = u.Id_usuario " +
				"Inner join Cidade c on c.Id_cidade = e.Cidade_Id_cidade";
			comando.Connection = conexao;
			comando.CommandText = query;
			leitor = comando.ExecuteReader();


			
			while (leitor.Read())
			{
				TableRow r = new TableRow();
				TableCell idC = new TableCell();
				TableCell nomeC = new TableCell();
				TableCell emailC = new TableCell();
				TableCell logradouro = new TableCell();
				TableCell complemento = new TableCell();
				TableCell bairro = new TableCell();
				TableCell cep = new TableCell();
				TableCell cidade = new TableCell();
				TableCell numero = new TableCell();

				idC.Controls.Add(new LiteralControl(leitor["id_usuario"].ToString()));
				nomeC.Controls.Add(new LiteralControl(leitor["nome"].ToString()));
				emailC.Controls.Add(new LiteralControl(leitor["email"].ToString()));
				logradouro.Controls.Add(new LiteralControl(leitor["logradouro"].ToString()));
				numero.Controls.Add(new LiteralControl(leitor["numero"].ToString()));
				complemento.Controls.Add(new LiteralControl(leitor["comp"].ToString()));
				bairro.Controls.Add(new LiteralControl(leitor["bairro"].ToString()));
				cep.Controls.Add(new LiteralControl(leitor["cep"].ToString()));
				cidade.Controls.Add(new LiteralControl(leitor["cidade"].ToString()));

				r.Cells.Add(idC);
				r.Cells.Add(nomeC);
				r.Cells.Add(emailC);
				r.Cells.Add(logradouro);
				r.Cells.Add(numero);
				r.Cells.Add(complemento);
				r.Cells.Add(bairro);
				r.Cells.Add(cep);
				r.Cells.Add(cidade);

				funcionarios.Rows.Add(r);
			}
			
			leitor.Close();
			
		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		protected void btnCad_Click(object sender, EventArgs e)
		{
			try
			{
				string selCidade = "select*from Cidade";
				comando.Connection = conexao;
				comando.CommandText = selCidade;
				leitor = comando.ExecuteReader();

				//determina se a cidade já existe
				bool exist = false;
				int idCit = 0;
				while (leitor.Read())
				{
					if (leitor["Nome_cidade"].ToString() == InsertCidade.Text)
					{
						exist = true;
						idCit = Convert.ToInt16(leitor["Id_cidade"]);
					}
					else
					{
						if (Convert.ToInt16(leitor["Id_cidade"]) > idCit)
						{
							idCit = Convert.ToInt16(leitor["Id_cidade"]);
						}
					}
				}
				leitor.Close();

				if (!exist)
				{
					//caso a cidade ainda nao exista ela insere na tabela
					string insertCidade = "insert into Cidade(`Nome_cidade`) values ('" + InsertCidade.Text + "')";
					comando.Connection = conexao;
					comando.CommandText = insertCidade;
					comando.ExecuteNonQuery();
				}

				string insertUser = "insert into Usuario(`Nome_usuario`,`Email_usuario`) values ('";

				insertUser += InsertNome.Text + "','";
				insertUser += InsertEmail.Text + "');";

				comando.Connection = conexao;
				comando.CommandText = insertUser;
				comando.ExecuteNonQuery();

				//determina maior Id para usuario
				string selUser = "select*from Usuario";
				comando.Connection = conexao;
				comando.CommandText = selUser;
				leitor = comando.ExecuteReader();

				int idUs = 0;
				while (leitor.Read())
				{
					if (Convert.ToInt16(leitor["Id_usuario"]) > idUs)
					{
						idUs = Convert.ToInt16(leitor["Id_usuario"]);
					}
				}
				leitor.Close();


				string insertEndereco = "insert into Endereco(`Logradouro`,`Complemento`,`Bairro`,`CEP`,`Cidade_Id_cidade`,`Numero`,`Usuario_Id_usuario`) values ('";

				insertEndereco += InsertLogradouro.Text + "','";
				insertEndereco += InsertComp.Text + "','";
				insertEndereco += InsertBairro.Text + "','";
				insertEndereco += InsertCEP.Text + "','";
				insertEndereco += idCit + 1 + "','";
				insertEndereco += InsertNumero.Text + "','";
				insertEndereco += idUs+ "')";


				comando.CommandText = insertEndereco;
				comando.ExecuteNonQuery();
			}

			catch (Exception Erro)
			{
				AlertInsert.CssClass = "alert alert-danger";
				AlertInsert.Attributes.Add("role","alert");
				AlertInsert.Text = Erro.ToString();
			}
			
		}

		protected void btnExcluir_Click(object sender, EventArgs e)
		{
			try
			{
				string delUser= "DELETE FROM `Usuario` WHERE Id_usuario = '";
				delUser += DelId.Text+"'";

				string delEnd = "Delete from `Usuario_Endereco` where Usuario_Id_usuario='";
				delEnd += DelId.Text + "'";

				comando.Connection = conexao;
				comando.CommandText = delEnd;
				comando.ExecuteNonQuery();
				comando.CommandText = delUser;
				comando.ExecuteNonQuery();
			}

			catch (Exception Erro)
			{
				DelAlert.CssClass = "alert alert-danger";
				DelAlert.Attributes.Add("role", "alert");
				DelAlert.Text = Erro.ToString();
			}
		}

		protected void btnAtualizar_Click(object sender, EventArgs e)
		{
			try
			{
				string attUser = "UPDATE `Usuario` SET `Nome_usuario`='" + AttNome.Text + "',`Email_usuario`='" + AttEmail.Text + "' WHERE Id_usuario ='" + AttId.Text + "'";
				comando.Connection = conexao;
				comando.CommandText = attUser;
				comando.ExecuteNonQuery();

				//determina se a cidade existe antes do update
				string selCity = "select*from Cidade";
				comando.Connection = conexao;
				comando.CommandText = selCity;
				leitor = comando.ExecuteReader();

				int idCity = 0;
				bool exists = false;
				while (leitor.Read())
				{
					//caso a cidade exista é pego apenas o ID da base de dados
					if (leitor["Nome_cidade"].ToString() == AttCidade.Text )
					{
						idCity = Convert.ToInt16(leitor["Id_cidade"]);
						exists = true;
					}
				}
				leitor.Close();

				if (!exists)
				{
					//Caso não exista é feito um Insert e capturado o ID para uso posterior
						string insertNovaCidade = "insert into Cidade(`Nome_cidade`) values ('";
						insertNovaCidade += AttCidade.Text + "')";
						comando.CommandText = insertNovaCidade;
						comando.ExecuteNonQuery();

						string queryID = "select*from Cidade";
						comando.Connection = conexao;
						comando.CommandText = queryID;
						leitor = comando.ExecuteReader();

						while (leitor.Read())
						{
							if (Convert.ToInt16(leitor["Id_cidade"]) > idCity)
							{
								idCity = Convert.ToInt16(leitor["Id_cidade"]);
							}
						}

						leitor.Close();
				}


				string attEnd = "Update `Endereco` SET `Logradouro`='" + AttLogradouro.Text + "',`Complemento`='" + AttComp.Text + "',`Bairro`='" + AttBairro.Text + "',`CEP`='" + AttCEP.Text + "',`Cidade_Id_cidade`='"+idCity+"',`Numero`='" + AttNumero.Text + "' where Usuario_Id_usuario ='" + AttId.Text + "'";
				comando.Connection = conexao;
				comando.CommandText = attEnd;
				comando.ExecuteNonQuery();
			}

			catch (Exception Erro)
			{
				AttAlert.CssClass = "alert alert-danger";
				AttAlert.Attributes.Add("role", "alert");
				AttAlert.Text = Erro.ToString();
			}
		}

		protected void btnConsulta_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < 3; i++) {
					funcionarios.Rows.RemoveAt(i);
				}

				string query = "select u.Id_usuario id_usuario, u.Nome_usuario nome, u.Email_usuario email, e.Logradouro logradouro, e.Complemento comp, e.Bairro bairro,e.CEP cep,c.Nome_cidade cidade,e.Numero numero from Endereco e " +
				"Inner join Usuario u on e.Usuario_Id_usuario = u.Id_usuario " +
				"Inner join Cidade c on c.Id_cidade = e.Cidade_Id_cidade where e.Usuario_Id_usuario >= '" + ConsultIdInicial.Text + "' and e.Usuario_Id_usuario <= '" + ConsultIdFinal.Text + "'";

				comando.Connection = conexao;
				comando.CommandText = query;
				leitor = comando.ExecuteReader();

				while (leitor.Read())
				{
					TableRow r = new TableRow();
					TableCell idC = new TableCell();
					TableCell nomeC = new TableCell();
					TableCell emailC = new TableCell();
					TableCell logradouro = new TableCell();
					TableCell complemento = new TableCell();
					TableCell bairro = new TableCell();
					TableCell cep = new TableCell();
					TableCell cidade = new TableCell();
					TableCell numero = new TableCell();

					idC.Controls.Add(new LiteralControl(leitor["id_usuario"].ToString()));
					nomeC.Controls.Add(new LiteralControl(leitor["nome"].ToString()));
					emailC.Controls.Add(new LiteralControl(leitor["email"].ToString()));
					logradouro.Controls.Add(new LiteralControl(leitor["logradouro"].ToString()));
					numero.Controls.Add(new LiteralControl(leitor["numero"].ToString()));
					complemento.Controls.Add(new LiteralControl(leitor["comp"].ToString()));
					bairro.Controls.Add(new LiteralControl(leitor["bairro"].ToString()));
					cep.Controls.Add(new LiteralControl(leitor["cep"].ToString()));
					cidade.Controls.Add(new LiteralControl(leitor["cidade"].ToString()));

					r.Cells.Add(idC);
					r.Cells.Add(nomeC);
					r.Cells.Add(emailC);
					r.Cells.Add(logradouro);
					r.Cells.Add(numero);
					r.Cells.Add(complemento);
					r.Cells.Add(bairro);
					r.Cells.Add(cep);
					r.Cells.Add(cidade);

					funcionarios.Rows.Add(r);
				}

				leitor.Close();
			}

			
			catch (Exception Erro)
			{
				AlertInsert.CssClass = "alert alert-danger";
				AlertInsert.Attributes.Add("role", "alert");
				AlertInsert.Text = Erro.ToString();
			}
			
		}
	}
}
 