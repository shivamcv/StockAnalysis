using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerPoint.Data;
using Xceed.Wpf.Toolkit;

namespace TriggerPoint.ViewModel
{
    public class DataDeletionViewModel : ViewModelBase
    {
        public DataDeletionViewModel()
        {
            reset();
        }

        private void reset()
        {
            t1 = t2 = t3 = t4 = t5 = t6 = t7 = t8 = t9 = t10 = t11 = t12 = true;

            IsScript = true;

            FromDate = ToDate = DateTime.Now;
        }

        private bool isScript = true;
        public bool IsScript
        {
            get { return isScript; }
            set
            {
                isScript = value;
                RaisePropertyChanged("IsScript");

                if (isScript)
                    using (var db = new Data.TriggerPointContext())
                    {
                        ScriptList = db.Tbl_ScriptMaster.AsEnumerable().Select(p => new KeyValuePair<int, string>(p.ID, p.ScriptName)).OrderBy(p => p.Value).ToList();
                        SelectedScript = ScriptList.FirstOrDefault();
                    }
            }
        }

        private bool isPortfolio;
        public bool IsPortfolio
        {
            get { return isPortfolio; }
            set
            {
                isPortfolio = value;
                RaisePropertyChanged("IsPortfolio");

                if (isPortfolio)
                    using (var db = new Data.TriggerPointContext())
                    {
                        ScriptList = db.Tbl_Portfolio.AsEnumerable().Select(p => new KeyValuePair<int, string>(p.PortfolioID, p.PortfolioName)).OrderBy(p => p.Value).ToList();
                        SelectedScript = ScriptList.FirstOrDefault();
                    }
            }
        }

        private bool isAll;
        public bool IsAll
        {
            get { return isAll; }
            set { isAll = value;
                RaisePropertyChanged("IsAll");
            }
        }
        

        private IEnumerable<KeyValuePair<int, string>> scriptList;
        public IEnumerable<KeyValuePair<int, string>> ScriptList
        {
            get { return scriptList; }
            set
            {
                scriptList = value;
                RaisePropertyChanged("ScriptList");
            }
        }

        private KeyValuePair<int, string> selectedScript;
        public KeyValuePair<int, string> SelectedScript
        {
            get { return selectedScript; }
            set
            {
                selectedScript = value;
                RaisePropertyChanged("SelectedScript");
            }
        }

       
       


        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value;
            RaisePropertyChanged("FromDate");
            }
        }

        private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value;
            RaisePropertyChanged("ToDate");
            }
        }

        #region Tables
        private bool _t1;

        public bool t1
        {
            get { return _t1; }
            set
            {
                _t1 = value;
                RaisePropertyChanged("t1");
            }
        }

        private bool _t2;

        public bool t2
        {
            get { return _t2; }
            set
            {
                _t2 = value;
                RaisePropertyChanged("t2");
            }
        }
        private bool _t3;

        public bool t3
        {
            get { return _t3; }
            set
            {
                _t3 = value;
                RaisePropertyChanged("t3");
            }
        }
        private bool _t4;

        public bool t4
        {
            get { return _t4; }
            set
            {
                _t4 = value;
                RaisePropertyChanged("t4");
            }
        }
        private bool _t5;

        public bool t5
        {
            get { return _t5; }
            set
            {
                _t5 = value;
                RaisePropertyChanged("t5");
            }
        }
        private bool _t6;

        public bool t6
        {
            get { return _t6; }
            set
            {
                _t6 = value;
                RaisePropertyChanged("t6");
            }
        }
        private bool _t7;

        public bool t7
        {
            get { return _t7; }
            set
            {
                _t7 = value;
                RaisePropertyChanged("t7");
            }
        }
        private bool _t8;

        public bool t8
        {
            get { return _t8; }
            set
            {
                _t8 = value;
                RaisePropertyChanged("t8");
            }
        }
        private bool _t9;

        public bool t9
        {
            get { return _t9; }
            set
            {
                _t9 = value;
                RaisePropertyChanged("t9");
            }
        }
        private bool _t10;

        public bool t10
        {
            get { return _t10; }
            set
            {
                _t10 = value;
                RaisePropertyChanged("t10");
            }
        }
        private bool _t11;

        public bool t11
        {
            get { return _t11; }
            set
            {
                _t11 = value;
                RaisePropertyChanged("t11");
            }
        }
        private bool _t12;

        public bool t12
        {
            get { return _t12; }
            set
            {
                _t12 = value;
                RaisePropertyChanged("t12");
            }
        } 
        #endregion

        private RelayCommand cancel;

        public RelayCommand Cancel
        {
            get { return  cancel ??(cancel = new RelayCommand(()=>
                {
                    reset();
                })); }
        }

        private RelayCommand delete;

        public RelayCommand Delete
        {
            get
            {
                return delete ?? (delete = new RelayCommand(() =>
                {
                    try
                    {
                        List<int> scripts = new List<int>();

                        if (IsScript)
                            scripts.Add(selectedScript.Key);
                        else if (IsPortfolio)
                            using (var db = new Data.TriggerPointContext())
                                foreach (var item in db.Tbl_ScriptPortfolio.Where(q => q.PortfolioID == selectedScript.Key))
                                {
                                    scripts.Add(item.ScriptID ?? 0);
                                }
                        else if (IsAll)
                        {
                            var r = MessageBox.Show("Are you sure you want to delete all data ?", "Delete all", System.Windows.MessageBoxButton.YesNoCancel, System.Windows.MessageBoxImage.Question);
                            if (r == System.Windows.MessageBoxResult.No || r == System.Windows.MessageBoxResult.Cancel)
                                return;

                            using (var db = new Data.TriggerPointContext())
                            {
                                scripts = db.Tbl_ScriptMaster.AsEnumerable().Select(p => p.ID).ToList();
                            }
                        }

                        var rows = 0;
                        foreach (var id in scripts)
                        {
                            using (var db = new TriggerPointContext())
                            {
                                if (t1)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script1Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t2)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script5Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;

                                }
                                if (t3)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script10Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t4)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script15Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t5)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script20Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t6)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script30Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t7)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script45Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t8)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script60Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t9)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script90Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t10)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script120Min", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t11)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_Script_Ami", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                if (t12)
                                {
                                    ObjectParameter result = new ObjectParameter("Result", typeof(String));
                                    db.DeleteData(FromDate, ToDate, id, "Tbl_ScriptEODMin", result);

                                    int t;
                                    int.TryParse(result.Value.ToString(), out t);
                                    rows += t;
                                }
                                db.SaveChanges();
                                reset();
                            }
                        }

                        MessageBox.Show(string.Format("{0} row(s) deleted", rows), "Rows Effected", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                    }
                    catch (Exception ex)
                    {
                        while (ex.InnerException != null)
                            ex = ex.InnerException;
                        MessageBox.Show(ex.Message, "Exception", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                    }
                },
                 () =>
                 {
                     if (!t1 && !t2 && !t3 && !t4 && !t5 && !t6 && !t7 && !t8 && !t9 && !t10 && !t11 && !t12)
                         return false;
                     return true;
                 }
                ));

                }
            }
        }
        
    }

