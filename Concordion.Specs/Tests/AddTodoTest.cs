﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concordion.Integration;
using TodoYouToo.Entities;
using Concordion.Specs.Utilities;
using Caliburn.Micro;
using TodoYouToo;
using TodoYouToo.Data;

namespace Concordion.Specs.Tests
{
    [ConcordionTest]
    class AddTodoTest
    {
        private static AppBootstrapper bootstrapper;
        private IMain mainVM;
        private ITodoRepository repo;
        private static IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

        private static DateTime ParseDate(String date){
            return DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }

        public AddTodoTest()
        {
            bootstrapper = new AppBootstrapper();
            repo = IoC.Get<ITodoRepository>();
            repo.RemoveAll();
        }

        public String isAppRunning()
        {
            try {
                mainVM = IoC.Get<IMain>();
                return "running";
            }catch(Exception ex){
                return "The app could not start : " + ex.ToString();
            }
        }

        public String clearDb()
        {
            try
            {
                repo.RemoveAll();
                if (repo.GetAll().Count() == 0) {
                    return "empty";
                }
                else {
                    return "still " + repo.GetAll().Count() + " elems in the database";
                }
            }
            catch (Exception ex)
            {
                return "The db had a problem : " + ex.ToString();
            }
        }

        public void setTodayDate(String today)
        {

            DateTimeProvider.MockedDate = ParseDate(today);
        }

        public String clickAddPopup()
        {
            try
            {
                mainVM.ShowPopup();
                return "clicked on the plus button";
            }
            catch (Exception ex)
            {
                return " Couldn't open the pop up " + ex.ToString();
            }
        }

        public void addTaskNamed(String name) {
            var popup = mainVM.AddTodoPopup;
            popup.Text = name;
            popup.Add();
        }
        public void addTask(String name, String dueDate)
        {
            var popup = mainVM.AddTodoPopup;
            popup.Text = name;
            popup.Date = ParseDate(dueDate);
            popup.Add();
        }

        public IEnumerable<TodoItem> getAllTasks()
        {
            return mainVM.TodoItems.ToArray();
        }

        public String getPopupStatus()
        {
            return mainVM.IsAddPopupVisible ? "open" : "closed";
        }

    }
}