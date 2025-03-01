﻿using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class ViewTrainers : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private List<Trainer> trainersList;
        protected void Page_Load(object sender, EventArgs e)
        {
            trainerBusiness = new TrainerBusiness();
            trainersList = new List<Trainer>();

            trainersList = trainerBusiness.List();

            dgvTrainersList.DataSource = trainersList;
            dgvTrainersList.DataBind();
        }

        protected void btnViewTrainer_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                string idTrainer = e.CommandArgument.ToString();
                Response.Redirect("ViewTrainer.aspx?idTrainer=" + idTrainer,false);
            }
        }

        protected void btnEditTrainer_Command(object sender, CommandEventArgs e)
        {

        }
    }
}