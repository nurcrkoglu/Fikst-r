using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections;

namespace Medepia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rd = new Random();

        model.LeagueStage ls = new model.LeagueStage();

        model.LeagueTable fb = new model.LeagueTable();
        model.LeagueTable gs = new model.LeagueTable();
        model.LeagueTable bjk = new model.LeagueTable();
        model.LeagueTable mucur = new model.LeagueTable();
        model.LeagueTable trabzon = new model.LeagueTable();
        model.LeagueTable sivas = new model.LeagueTable();
        model.LeagueTable team1 = new model.LeagueTable();
        model.LeagueTable team2 = new model.LeagueTable();

        parser deneme = new parser();

        private void Form1_Load(object sender, EventArgs e)
        {
            string leagueStage = "{\"id\": \"1\", \"name\": \"2017/2018 Sezonu\", \"tournamentName\": \"Spor Toto Süper Lig\",\"logo\": \"http://zmdp.cloud/iseAlim/images/1.png\"}";

            ls = JsonConvert.DeserializeObject<model.LeagueStage>(leagueStage);
            //  deneme.parse();

            lbl_ls_name.Text = ls.name;
            lbl_ls_tourname.Text = ls.tournamentName;
            pb_ls_logo.ImageLocation = ls.logo;



            string json = @"[
                {
                    'teamId':1,
                    'name':'Fenerbahçe',
                    'overall':75,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/2.png'
                 },
                {
                   'teamId':2,
                    'name':'Galatasaray',
                    'overall':74,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/3.png'
                },
                {
                    'teamId':3,
                    'name':'Beşiktaş',
                    'overall':77,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/4.png'
                },
                {   'teamId':4,
                    'name':'Mucur Gücü',
                    'overall':73,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/5.png'
                },
                {
                    'teamId':5,
                    'name':'Trabzonspor',
                    'overall':72,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/6.png'
                },
                {   'teamId':6,
                    'name':'Demir Grup Sivasspor',
                    'overall':70,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/7.png'
                }

]";

            JArray leagueTableArray = JArray.Parse(json);

            IList<model.LeagueTable> leagueTable = leagueTableArray.Select(p => new model.LeagueTable
            {
                teamId = (int)p["teamId"],
                name = (string)p["name"],
                overall = (int)p["overall"],
                teamLogo = (string)p["teamLogo"]
            }).ToList();


            //week1

            lblfb1.Text = leagueTable[0].name;
            lblGS1.Text = leagueTable[1].name;
            lblBJK1.Text = leagueTable[2].name;
            lblBasak1.Text = leagueTable[3].name;
            lblTrabzon1.Text = leagueTable[4].name;
            lblsivas1.Text = leagueTable[5].name;

            //week2
            lblfb2.Text = leagueTable[0].name;
            lblgs2.Text = leagueTable[1].name;
            lblBjk2.Text = leagueTable[2].name;
            lblbasak2.Text = leagueTable[3].name;
            lbltrabzon2.Text = leagueTable[4].name;
            lblsivas2.Text = leagueTable[5].name;

            //week3
            lblFb3.Text = leagueTable[0].name;
            lblGs3.Text = leagueTable[1].name;
            lblBjk3.Text = leagueTable[2].name;
            lblBasak3.Text = leagueTable[3].name;
            lblTrabzon3.Text = leagueTable[4].name;
            lblSivas3.Text = leagueTable[5].name;

            //week4
            lblFb4.Text = leagueTable[0].name;
            lblGs4.Text = leagueTable[1].name;
            lblBjk4.Text = leagueTable[2].name;
            lblBasak4.Text = leagueTable[3].name;
            lblTrabzon4.Text = leagueTable[4].name;
            lblSivas4.Text = leagueTable[5].name;

            //week5
            lblFb5.Text = leagueTable[0].name;
            lblGs5.Text = leagueTable[1].name;
            lblBjk5.Text = leagueTable[2].name;
            lblBasak5.Text = leagueTable[3].name;
            lblTrabzon5.Text = leagueTable[4].name;
            lblSivas5.Text = leagueTable[5].name;

            createTable();


            btnMac.Visible = false;
            grp2.Visible = false;
            btnGelecek3.Visible = false;
            grp3.Visible = false;
            btnGelecek4.Visible = false;
            btnGelecek5.Visible = false;
            grp4.Visible = false;
            grp5.Visible = false;

            

        }
     /*  public void randomTeam()
        {
            DataTable table = new DataTable();
            DataRow rows = table.NewRow();
            table.Columns.Add("Takımlar");
            table.Columns.Add("Takımlar1");
            table.Columns.Add("Score");
            table.Columns.Add("Score1");

            List<string> myTakimlar = new List<string>(new string[] { "Fenerbahçe", "Galatasaray", "Beşiktaş", "Grup Demir Sivasspor", "Mucur Gücü", "Trabzonspor" });
            string[,] dizi = new string[(myTakimlar.Count / 2), 2];
            string[,] dizi1 = new string[(myTakimlar.Count / 2), 2];


            int random = 0, random1 = 0;

            for (int i = 0; i < 3; i++)
            {
                random = rd.Next(0, myTakimlar.Count);
                random1 = rd.Next(0, myTakimlar.Count);

                while (random == random1)
                {
                    random1 = rd.Next(0, myTakimlar.Count);

                }

                dizi[i, 0] = myTakimlar[random];
                dizi1[i, 1] = myTakimlar[random1];
                myTakimlar.RemoveAt(random);
                random1 = random1 > random ? random1 - 1 : random1;
                myTakimlar.RemoveAt(random1);
    
                table.Rows.Add(dizi[i, 0], dizi1[i, 1], rd.Next(0, 6), rd.Next(0, 6));

            }
        }
     */
        private void btnWeek1_Click(object sender, EventArgs e)
        {

            lblskorfb1.Text = rd.Next(0, 6).ToString();
            lblskorgs1.Text = rd.Next(0, 6).ToString();
            lblskorsivas1.Text = rd.Next(0, 6).ToString();
            lblskortrabzon1.Text = rd.Next(0, 6).ToString();
            lblskorbasak1.Text = rd.Next(0, 6).ToString();
            lblskorBjk1.Text = rd.Next(0, 6).ToString();

            compareTeam(Convert.ToInt32(lblskorfb1.Text), Convert.ToInt32(lblskortrabzon1.Text), fb, trabzon);
            compareTeam(Convert.ToInt32(lblskorgs1.Text), Convert.ToInt32(lblskorsivas1.Text), gs, sivas);
            compareTeam(Convert.ToInt32(lblskorbasak1.Text), Convert.ToInt32(lblskorBjk1.Text), mucur, bjk);


            btnOynat.Enabled = false;
            btnMac.Visible = true;


        }
        private void btnWeek2_Click(object sender, EventArgs e)
        {

            lblFbSkor2.Text = rd.Next(0, 6).ToString();
            lblGsSkor2.Text = rd.Next(0, 6).ToString();
            lblTrabzonSkor2.Text = rd.Next(0, 6).ToString();
            lblBasakSkor2.Text = rd.Next(0, 6).ToString();
            lblBjkSkor2.Text = rd.Next(0, 6).ToString();
            lblSivasSkor2.Text = rd.Next(0, 6).ToString();

            compareTeam(Convert.ToInt32(lblGsSkor2.Text), Convert.ToInt32(lblTrabzonSkor2.Text), gs, trabzon);
            compareTeam(Convert.ToInt32(lblBasakSkor2.Text), Convert.ToInt32(lblFbSkor2.Text), mucur, fb);
            compareTeam(Convert.ToInt32(lblSivasSkor2.Text), Convert.ToInt32(lblBjkSkor2.Text), sivas, bjk);

            btnhafta2.Enabled = false;
            btnGelecek3.Visible = true;

        }
        private void btnWeek3_Click(object sender, EventArgs e)
        {
            lblSkorFb3.Text = rd.Next(0, 6).ToString();
            lblSkorGs3.Text = rd.Next(0, 6).ToString();
            lblSkorTrabzon3.Text = rd.Next(0, 6).ToString();
            lblSkorBasak3.Text = rd.Next(0, 6).ToString();
            lblSkorBjk3.Text = rd.Next(0, 6).ToString();
            lblSkorSivas3.Text = rd.Next(0, 6).ToString();

            compareTeam(Convert.ToInt32(lblSkorTrabzon3.Text), Convert.ToInt32(lblSkorBjk3.Text), trabzon, bjk);
            compareTeam(Convert.ToInt32(lblSkorFb3.Text), Convert.ToInt32(lblSkorGs3.Text), fb, gs);
            compareTeam(Convert.ToInt32(lblSkorBasak3.Text), Convert.ToInt32(lblSkorSivas3.Text), mucur, sivas);

            btnHafta3.Enabled = false;
            btnGelecek4.Visible = true;

        }
        private void btnWeek4_Click(object sender, EventArgs e)
        {
            lblFbSkor4.Text = rd.Next(0, 6).ToString();
            lblGsSkor4.Text = rd.Next(0, 6).ToString();
            lblSivasSkor4.Text = rd.Next(0, 6).ToString();
            lblTrabzonSkor4.Text = rd.Next(0, 6).ToString();
            lblBasakSkor4.Text = rd.Next(0, 6).ToString();
            lblBjkSkor4.Text = rd.Next(0, 6).ToString();

            compareTeam(Convert.ToInt32(lblFbSkor4.Text), Convert.ToInt32(lblBjkSkor4.Text), fb, bjk);
            compareTeam(Convert.ToInt32(lblTrabzonSkor4.Text), Convert.ToInt32(lblSivasSkor4.Text), trabzon, sivas);
            compareTeam(Convert.ToInt32(lblGsSkor4.Text), Convert.ToInt32(lblBasakSkor4.Text), gs, mucur);

            btnHafta4.Enabled = false;
            btnGelecek5.Visible = true;

        }
        private void btnWeek5_Click(object sender, EventArgs e)
        {
            lblFbSkor5.Text = rd.Next(0, 6).ToString();
            lblGsSkor5.Text = rd.Next(0, 6).ToString();
            lblSivasSkor5.Text = rd.Next(0, 6).ToString();
            lblTrabzonSkor5.Text = rd.Next(0, 6).ToString();
            lblBasakSkor5.Text = rd.Next(0, 6).ToString();
            lblBjkSkor5.Text = rd.Next(0, 6).ToString();

            compareTeam(Convert.ToInt32(lblFbSkor5.Text), Convert.ToInt32(lblSivasSkor5.Text), fb, sivas);
            compareTeam(Convert.ToInt32(lblGsSkor5.Text), Convert.ToInt32(lblBjkSkor5.Text), gs, bjk);
            compareTeam(Convert.ToInt32(lblBasakSkor5.Text), Convert.ToInt32(lblTrabzonSkor5.Text), mucur, trabzon);

            btnHafta5.Enabled = false;
            btnGelecek6.Visible = true;
        }
        private void btnGelecek4_Click(object sender, EventArgs e)
        {
            grp4.Visible = true;
        }
        private void btnMac_Click(object sender, EventArgs e)
        {
            grp2.Visible = true;
        }
        private void btnGelecek3_Click(object sender, EventArgs e)
        {
            grp3.Visible = true;
        }
        private void createTable()
        {
            DataTable table = new DataTable();
            DataRow rows = table.NewRow();
            table.Columns.Add("Takım");
            table.Columns.Add("Oynanan Maç");
            table.Columns.Add("Galibiyet");
            table.Columns.Add("Mağlubiyet");
            table.Columns.Add("Beraberlik");
            table.Columns.Add("Puan");

            table.Rows.Add("Fenerbahçe", fb.playedMatch, fb.win, fb.loss, fb.onTerms, fb.score);
            table.Rows.Add("Beşiktaş", bjk.playedMatch, bjk.win, bjk.loss, bjk.onTerms, bjk.score);
            table.Rows.Add("Galatasaray", gs.playedMatch, gs.win, gs.loss, gs.onTerms, gs.score);
            table.Rows.Add("Mucur", mucur.playedMatch, mucur.win, mucur.loss, mucur.onTerms, mucur.score);
            table.Rows.Add("Trabzonspor", trabzon.playedMatch, trabzon.win, trabzon.loss, trabzon.onTerms, trabzon.score);
            table.Rows.Add("Sivasspor", sivas.playedMatch, sivas.win, sivas.loss, sivas.onTerms, sivas.score);

            dataGridView1.DataSource = table;
            dataGridView1.Sort(dataGridView1.Columns[5], System.ComponentModel.ListSortDirection.Descending);


        }
        private void compareTeam(int team1, int team2, model.LeagueTable team1Name, model.LeagueTable team2Name)
        {
            if (team1 > team2)
            {
                team1Name.score += 3;
                team1Name.playedMatch++;
                team2Name.playedMatch++;

                team1Name.win++;
                team2Name.loss++;

                createTable();

            }
            else if (team1 == team2)
            {
                team1Name.score++;
                team2Name.score++;

                team1Name.playedMatch++;
                team2Name.playedMatch++;

                team1Name.onTerms++;
                team2Name.onTerms++;

                createTable();
            }
            else
            {
                team2Name.score += 3;

                team1Name.playedMatch++;
                team2Name.playedMatch++;

                team1Name.loss++;
                team2Name.win++;

                createTable();
            }

        }
        private void btnGelecek5_Click(object sender, EventArgs e)
        {
            grp5.Visible = true;
        }
       
    }      
        }
    

    
   


