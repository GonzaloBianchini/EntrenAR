﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using Domain;


namespace ViewModel
{
    public partial class TrainerViewExercises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExercisesBusiness exercisesBusiness = new ExercisesBusiness();
            List<Exercise> ExerciseList = exercisesBusiness.List();

            dgvExerciseList.DataSource = ExerciseList;
            dgvExerciseList.DataBind();
        }
    }
}