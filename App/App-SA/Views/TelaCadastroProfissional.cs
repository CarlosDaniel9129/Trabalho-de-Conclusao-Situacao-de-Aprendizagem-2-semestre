﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App_SA.Models;
using App_SA.Controller;

namespace App_SA
{
    public partial class TelaCadastroProfissional : Form
    {
        Controle controle = new Controle();

        public TelaCadastroProfissional()
        {
            InitializeComponent();
            
            //if ()//ja é cadastrado?
            //{
            //   // mostrar botao pesquisar profissional
            //}
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaLogin().Show();
            Visible = false;
        }

        private void btnSalvarProfissional_Click(object sender, EventArgs e)
        {            
            try
            {
                if (txtNome.Text == string.Empty || !maskedTxtCpf.MaskCompleted || maskedTxtValorHora.MaskCompleted
                    || !maskedTelefone.MaskCompleted || txtEmail.Text == string.Empty || txtSenha.Text == string.Empty 
                    || txtConfirmarSenha.Text == string.Empty || cbProfissao.Text == string.Empty || cbFormacao.Text == string.Empty
                    || cbEstado.Text == string.Empty || txtCidade.Text == string.Empty || txtBairro.Text == string.Empty)
                {
                    ControlarVisibilidade();
                }
                else
                {
                    Profissional profissional = new Profissional()
                    {
                        Nome = txtNome.Text,
                        Cpf = txtEmail.Text,
                        Senha = txtSenha.Text,
                        Email = txtEmail.Text,
                        Sexo = cbSexo.Text,
                        ValorHora = double.Parse(maskedTxtValorHora.Text),
                        Infos = richTxtInformacoesAdicionais.Text,
                        Profissao = cbProfissao.Text,
                        Formacao = cbFormacao.Text,
                        Estado = cbEstado.Text,
                        Cidade = txtCidade.Text,
                        Bairro = txtBairro.Text
                    };

                    profissional.cadastraDados();

                    new TelaLogin().Show();
                    Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro. {ex.Message}");
            }
        }

        private void ControlarVisibilidade()
        {
            lblAtencao.Visible = true;

            if (txtNome.Text == string.Empty)
                lblNome.ForeColor = Color.Red;
            else
                lblNome.ForeColor = Color.White;

            if (!maskedTxtCpf.MaskCompleted)
                lblCpf.ForeColor = Color.Red;
            else
                lblCpf.ForeColor = Color.White;

            if (!maskedTelefone.MaskCompleted)
                lblTelefone.ForeColor = Color.Red;
            else
                lblTelefone.ForeColor = Color.White;

            if (!maskedTxtValorHora.MaskCompleted)
                lblValorHora.ForeColor = Color.Red;
            else
                lblValorHora.ForeColor = Color.White;

            if (txtEmail.Text == string.Empty)
                lblEmail.ForeColor = Color.Red;
            else
                lblEmail.ForeColor = Color.White;

            if (txtSenha.Text == string.Empty)
                lblSenha.ForeColor = Color.Red;
            else
                lblSenha.ForeColor = Color.White;

            if (txtConfirmarSenha.Text == string.Empty)
                lblConfirmarSenha.ForeColor = Color.Red;
            else
                lblConfirmarSenha.ForeColor = Color.White;

            if (cbProfissao.Text == string.Empty)
                lblProfissao.ForeColor = Color.Red;
            else
                lblProfissao.ForeColor = Color.White;

            if (cbFormacao.Text == string.Empty)
                lblFormacao.ForeColor = Color.Red;
            else
                lblFormacao.ForeColor = Color.White;

            if (cbEstado.Text == string.Empty)
                lblEstado.ForeColor = Color.Red;
            else
                lblEstado.ForeColor = Color.White;

            if (txtCidade.Text == string.Empty)
                lblCidade.ForeColor = Color.Red;
            else
                lblCidade.ForeColor = Color.White;

            if (txtBairro.Text == string.Empty)
                lblBairro.ForeColor = Color.Red;
            else
                lblBairro.ForeColor = Color.White;

            return;
        }

        private void btnPesquisaProfissional_Click(object sender, EventArgs e)
        {
            new TelaPesquisa().Show();
            Visible = false;
        }

        private void btnCarregarFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
