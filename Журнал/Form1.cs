﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Журнал
{
    public partial class Form1 : Form
    {
        public static string connectionstring = Properties.Settings.Default.ЖурналConnectionString;
        public string SqlStr = "";
        public OleDbConnection connection = new OleDbConnection(connectionstring);


        public Form1()
        {
            InitializeComponent();
        }
        private BindingSource bindingSource1;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlStr = "SELECT " +
                        "Ученики.[Фамилия]," +
                        " Ученики.[Имя]," +
                        " Ученики.[Отчество]," +
                        " Дисциплины.[Название] AS [Дисциплина]," +
                        " Оценки.[Оценки] " +
                        "FROM Оценки, Ученики, Дисциплины " +
                        "where Ученики.[Код] = Оценки.[Код ученика] and Дисциплины.[Код] = Оценки.[Код дисциплины]";
            OleDbDataAdapter Adapter = new OleDbDataAdapter(SqlStr, connection);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            MainGrid.AutoGenerateColumns = true;
            MainGrid.DataSource = Table;

            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Table;           
            MainGrid.DataSource = bindingSource1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Добавить_оценку f2 = new Добавить_оценку();
            f2.Show();
        }

        public void UpdBtn_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlStr = "SELECT " +
                        "Ученики.[Фамилия]," +
                        " Ученики.[Имя]," +
                        " Ученики.[Отчество]," +
                        " Дисциплины.[Название] AS [Дисциплина]," +
                        " Оценки.[Оценки] " +
                        "FROM Оценки, Ученики, Дисциплины " +
                        "where Ученики.[Код] = Оценки.[Код ученика] and Дисциплины.[Код] = Оценки.[Код дисциплины]";
            OleDbDataAdapter Adapter = new OleDbDataAdapter(SqlStr, connection);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            MainGrid.AutoGenerateColumns = true;
            MainGrid.DataSource = Table;

            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Table;
            MainGrid.DataSource = bindingSource1;

        }
    }
}
