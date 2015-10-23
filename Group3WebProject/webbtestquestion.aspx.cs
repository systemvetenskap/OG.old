using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
namespace Group3WebProject
{
    public partial class webbtestquestion : System.Web.UI.Page
    {
        string testID = "2";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Debug.WriteLine("Startat");

              //  Classes.clsFillMenu aa = new Classes.clsFillMenu();
                Classes.clsTestMenuFill aa = new Classes.clsTestMenuFill();
                alque.DataValueField = "id";
                alque.DataTextField = "name";
                alque.DataSource = aa.read(Server.MapPath("~/questions.xml"));
                Debug.WriteLine(aa.read(Server.MapPath("~/questions.xml")).Rows.Count.ToString());

                alque.DataBind();
                if (alque.Items.Count > 0)
                {
                    ViewState["alfred"] = alque.SelectedItem.ToString();
                    queston.DataTextField = "name";
                    queston.DataValueField = "id";
                    queston.DataSource = fillQuestions(alque.SelectedValue); ;
                    queston.DataBind();
                    checkedRadion();
                }
                else
                {
                    Label1.Text = "Något gick fel försök igen";
                    Button1.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrevious.Enabled = false;
                    queston.Enabled = false;
                    alque.Enabled = false;
                }

                
            }
            else
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ala();
            ViewState["alfred"] = alque.SelectedValue.ToString();
            Classes.clsRightOrNot cls = new Classes.clsRightOrNot();
            Label2.Text = cls.allReadyCheckd(alque.SelectedValue.ToString(), testID);

        }
        private bool ala()//Hämtar frågorna 
        {
            checkAnswers(queston);
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            queston.DataTextField = "name";
            queston.DataValueField = "id";
            queston.DataSource = fillQuestions(alque.SelectedValue); ;
            queston.DataBind();
            return true;
        }
        private void checkedRadion()//Vilken som redan är vald och då checkar den i uppstarten 
        {
            Classes.clsRightOrNot cls = new Classes.clsRightOrNot();
            Label2.Text = cls.allReadyCheckd(alque.SelectedValue.ToString(), testID);
            queston.SelectedValue = cls.allReadyCheckd(alque.SelectedValue.ToString(), testID);

        }

        private bool checkAnswers(RadioButtonList aa)//Sparar svars alternativen
        {
            try
            {
                Classes.clsRightOrNot cls = new Classes.clsRightOrNot();
                if (aa.SelectedIndex > 0)
                {
                    Label3.Text = cls.saveAnswers(alque.SelectedValue.ToString(), aa.SelectedValue.ToString(), testID);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return true;
        }
        private DataTable fillQuestions(string questionID)//Bara en nästling som går att flytta bort 
        {
            Classes.clsFillQuestion aa = new Classes.clsFillQuestion();
            return aa.readXML(questionID, Server.MapPath("~/questions.xml"));
        }
        protected void queston_Unload(object sender, EventArgs e)
        {

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            // Label1.Text = ViewState["alfred"].ToString();
            ala();
            ViewState["alfred"] = alque.SelectedValue.ToString();
            if (alque.Items.Count > alque.SelectedIndex + 1)
            {
                alque.SelectedIndex = alque.SelectedIndex + 1;
            }
            checkedRadion();
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            ala();
            ViewState["alfred"] = alque.SelectedItem.ToString();
            if (alque.Items.Count > alque.SelectedIndex - 1)
            {
                alque.SelectedIndex = alque.SelectedIndex - 1;
            }
            checkedRadion();
        }
        protected void alque_SelectedIndexChanged(object sender, EventArgs e)
        {
            ala();
            ViewState["alfred"] = alque.SelectedItem.ToString();
            checkedRadion();
        }
    }
}