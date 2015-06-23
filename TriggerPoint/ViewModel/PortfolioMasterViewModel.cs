using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TriggerPoint.Data;

namespace TriggerPoint.ViewModel
{
   public class PortfolioMasterViewModel:ViewModelBase
    {
       int userId;
        public PortfolioMasterViewModel()
       {
            userId = SimpleIoc.Default.GetInstance<LoginViewModel>().CurrentUser.IDUser;

           ScriptList = new ObservableCollection<Script>();
           SelectedScripts = new ObservableCollection<Script>();
           PortfolioList = new ObservableCollection<string>();

         

           using (var db = new TriggerPointContext())
           {
               foreach (var item in db.Tbl_Portfolio.Where(p=>p.UserID == userId && p.IsDelete==false))
               {
                   PortfolioList.Add(item.PortfolioName);
               }
           }

           loadScripts();
       }

        public ObservableCollection<string> PortfolioList { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { 
                if (name == value) return;
                 name = value;
                 RaisePropertyChanged("Name");

                 SelectedScripts.Clear();

                if(PortfolioList.Contains(name))
                {
                    using (var db = new TriggerPointContext())
                    {
                        if (db.Tbl_Portfolio.FirstOrDefault(p => p.PortfolioName == name) == null)
                            return;

                        int portfolioid = db.Tbl_Portfolio.FirstOrDefault(p=>p.PortfolioName == name).PortfolioID;
                        foreach (var item in db.Tbl_ScriptPortfolio.Where(p=>p.PortfolioID == portfolioid))
                        {
                            var script = ScriptList.FirstOrDefault(p => p.Id == (item.ScriptID??0));

                            if(script != null)
                            {
                                SelectedScripts.Add(script);
                                script.IsSelected = true;
                            }
                           
                        }
                    }
                }
               
               
            }
        }

        private string query;
        public string Query
        {
            get { return query; }
            set {
                if (query == value) return;
                query = value;
            RaisePropertyChanged("Query");
            loadScripts();
            }
        }

        private void loadScripts()
        {
            ScriptList.Clear();
            using (var db = new TriggerPointContext())
            {
                foreach (var item in string.IsNullOrEmpty(query)?db.Tbl_ScriptMaster: db.Tbl_ScriptMaster.Where(p=>p.ScriptName.Contains(query)))
                {
                    var temp = new Script() { Name = item.ScriptName, Id = item.ID};
                    if (SelectedScripts.Contains(temp))
                        temp = SelectedScripts.FirstOrDefault(p => p.Id == temp.Id);
                    ScriptList.Add(temp);
                   

                }
            }
        }

        public ObservableCollection<Script> ScriptList { get; set; }
        public ObservableCollection<Script> SelectedScripts { get; set; }

        private RelayCommand save;

        public RelayCommand Save
        {
            get
            {
                return save ?? (save = new RelayCommand(() =>
                    {
                        using (var db = new TriggerPointContext())
                        {
                            var portfolio = db.Tbl_Portfolio.FirstOrDefault(p => p.PortfolioName == Name);

                            if(portfolio == null) //add portfolio name if not persent
                            {
                              portfolio =  db.Tbl_Portfolio.Add(new Tbl_Portfolio()
                                                    {
                                                        PortfolioName = Name,
                                                        UserID = userId,
                                                        IsDelete = false,
                                                        CreatedDate = DateTime.Now,
                                                    });
                              db.SaveChanges();
                              
                            }

                            var temp = db.Tbl_ScriptPortfolio.AsEnumerable().Where(p => p.PortfolioID == portfolio.PortfolioID && !SelectedScripts.Contains(new Script() { Id = p.ScriptID??0})).AsEnumerable();

                            db.Tbl_ScriptPortfolio.RemoveRange(temp);
                            

                            foreach (var script in SelectedScripts)
                            {
                                if(db.Tbl_ScriptPortfolio.FirstOrDefault(p=>p.PortfolioID == portfolio.PortfolioID && p.ScriptID == script.Id) == null)
                                      db.Tbl_ScriptPortfolio.Add(new Tbl_ScriptPortfolio()
                                                            {
                                                                EnterDate = DateTime.Now,
                                                                PortfolioID = portfolio.PortfolioID,
                                                                ScriptID = script.Id,
                                                                UserID = userId,
                                                            });
                            }

                            db.SaveChanges();
                        }
                            Reset();
                    },
                    () =>
                    {
                        if (string.IsNullOrEmpty(Name))
                            return false;

                        return true;
                    }));
            }
        }

        private RelayCommand delete;

        public RelayCommand Delete
        {
            get
            {
                return delete ?? (delete = new RelayCommand(() =>
                    {
                        using (var db = new TriggerPointContext())
                        {
                            var portfolio = db.Tbl_Portfolio.FirstOrDefault(p => p.PortfolioName == Name);
                            
                            if(portfolio != null)
                            {
                                db.Tbl_ScriptPortfolio.RemoveRange(db.Tbl_ScriptPortfolio.Where(p => p.PortfolioID == portfolio.PortfolioID));
                                db.Tbl_Portfolio.Remove(portfolio);
                                db.SaveChanges();
                            }
                        }
                            Reset();
                    },
                    () =>
                    {
                        if (SelectedScripts.Count > 0 || !string.IsNullOrEmpty(Name))
                            return true;

                        return false;
                    }));
            }
        }

        private void Reset()
        {
            SelectedScripts.Clear();
            Name = string.Empty;

            foreach (var item in ScriptList)
            {
                item.IsSelected = false;
            }

            using (var db = new TriggerPointContext())
            {
                PortfolioList.Clear();
                foreach (var item in db.Tbl_Portfolio.Where(p => p.UserID == userId && p.IsDelete == false))
                {
                    PortfolioList.Add(item.PortfolioName);
                }
            }
        }


        private RelayCommand<Script> selectScript;

        public RelayCommand<Script> SelectScript
        {
            get { return selectScript??(selectScript = new RelayCommand<Script>((p)=>
                {
                    if (!p.IsSelected)
                    {
                        SelectedScripts.Remove(p);
                    }
                    else if (!SelectedScripts.Contains(p))
                        SelectedScripts.Add(p);

                   
                    //p.IsSelected = !p.IsSelected;

                })); }
        }

        private RelayCommand<bool> selectAll;

        public RelayCommand<bool> SelectAll
        {
            get
            {
                return selectAll ?? (selectAll = new RelayCommand<bool>((p) =>
                    {
                        if (p== true)
                        {
                            foreach (var item in ScriptList)
                            {
                                if (!item.IsSelected)
                                {
                                    item.IsSelected = true;
                                    selectScript.Execute(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in ScriptList)
                            {
                                if (item.IsSelected)
                                {
                                    item.IsSelected = false;
                                    selectScript.Execute(item);
                                }
                            }
                        }

                    }));
            }
        }
        
    }

    public class Script:ViewModelBase
    {
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
            RaisePropertyChanged("IsSelected");
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            if(obj is Script)
            return Id == ((Script)obj).Id;

            return false;
        }

    }

   
}
