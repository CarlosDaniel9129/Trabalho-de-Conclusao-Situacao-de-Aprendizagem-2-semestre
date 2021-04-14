﻿using App_SA.Controller;
using App_SA.Models;
using App_SA.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App_SA
{
    public partial class TelaPesquisa : Form
    { 

        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;
        public TelaPesquisa()//recebo por parametro um objeto do tipo FORM
        {
            InitializeComponent();
        }

        

        private void btnMinhaConta_Click(object sender, EventArgs e)
        {
            bool ehlogado = Comandos.Logado;

            if (ehlogado)
            {
                new TelaCadastroProfissional().Show();
                Visible = false;
            }
            else
            {
                new TelaLogin().Show();
                Visible = false;
            }            
        }

        private void apresentaDados()
        {
            mDataSet = new DataSet();
            mConn = new MySqlConnection("server=localhost;user id=root;database=workers");
            mConn.Open();

            //cria um adapter utilizando a instrução SQL para aceder à tabela
            mAdapter = new MySqlDataAdapter("select nome, profissao, estado, cidade, formacao, valorHora, telefone from usuario order by idUsuario", mConn);

            //preenche o dataset através do adapter
            mAdapter.Fill(mDataSet, "usuario");

            //atribui o resultado à propriedade DataSource da dataGridView
            gridProfissionais.DataSource = mDataSet;
            gridProfissionais.DataMember = "usuario";
        }

            private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            Visible = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            apresentaDados();
        }

        private void gridProfissionais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gridProfissionais.CurrentRow.Selected.ToString();
            new TelaMostrarProfissional().Show();
            Visible = false;
        }
    }
}
