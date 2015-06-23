using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriggerPoint.Model;
using TriggerPoint.Properties;

namespace TriggerPoint.ViewModel
{
   public class IndicatorDataViewModel:ViewModelBase
    {
       private readonly string STORAGEFILE;
       public IndicatorDataViewModel()
       {
           STORAGEFILE = Path.Combine(App.DataFolder, "ColumnData.xml");

           Indicators = new string[] {IndicatorEnum.Average.ToString(),
                                       IndicatorEnum.BollingerBand.ToString(),
                                       IndicatorEnum.MACD.ToString(),
                                       IndicatorEnum.RSI.ToString(),
                                       IndicatorEnum.Swing.ToString()};

           if (File.Exists(STORAGEFILE))
               IndicatorData = HelperClasses.XMLHelper.readXml<IndicatorStoredData>(STORAGEFILE);
           else
               IndicatorData = new IndicatorStoredData();

       }

        public IndicatorStoredData IndicatorData { get; set; }

        private IEnumerable<string> indicators;

        public IEnumerable<string> Indicators
        {
            get { return indicators; }
            set { indicators = value;
                RaisePropertyChanged("Indicators");
              
            }
        }

        private string selectedIndicator;

        public string SelectedIndicator
        {
            get { return selectedIndicator; }
            set { selectedIndicator = value;
                  RaisePropertyChanged("SelectedIndicator");
                  if (!string.IsNullOrEmpty(value))
                  {
                      AllColumns = IndicatorData.AllColumns[stringToIndicatorEnum(value)];

                      ProfileList = IndicatorData.GetProfiles(stringToIndicatorEnum(value)).Select(p => p.Name);

                      if (IndicatorData.ActiveProfiles.ContainsKey(stringToIndicatorEnum(value)) && IndicatorData.ActiveProfiles[stringToIndicatorEnum(value)]!= null)
                          ActiveProfile = IndicatorData.ActiveProfiles[stringToIndicatorEnum(value)].Name;
                      else
                          ActiveProfile = null;

                      if (activeProfile == null)
                      {
                          VisibleColumns = new ObservableCollection<string>(IndicatorData.AllColumns[stringToIndicatorEnum(value)]);
                          SelectedFont = new Font(FontFamily.Families.First(), 12);
                      }
                  }
            }
        }

        private string selectedColumn;

        public string SelectedColumn
        {
            get { return selectedColumn; }
            set { selectedColumn = value;
            RaisePropertyChanged("SelectedColumn");
            }
        }

        private string selectedVisibleColumn;

        public string SelectedVisibleColumn
        {
            get { return selectedVisibleColumn; }
            set { selectedVisibleColumn = value;
            RaisePropertyChanged("SelectedVisibleColumn");
            }
        }

        private IEnumerable<string> allColumns;

        public IEnumerable<string> AllColumns
        {
            get { return allColumns; }
            set { allColumns = value;
            RaisePropertyChanged("AllColumns");
            }
        }

        private ObservableCollection<String> visibleColumns;

        public ObservableCollection<String> VisibleColumns
        {
            get { return visibleColumns; }
            set { visibleColumns = value;
            RaisePropertyChanged("VisibleColumns");
            }
        }

        private Font selectedFont;

        public Font SelectedFont
        {
            get { return selectedFont; }
            set { selectedFont = value;
            RaisePropertyChanged("SelectedFont");
            }
        }

        private string profileName;

        public string ProfileName
        {
            get { return profileName; }
            set { profileName = value;
                    RaisePropertyChanged("ProfileName");
            }
        }


        private IEnumerable<string> profileList;

        public IEnumerable<string> ProfileList
        {
            get { return profileList; }
            set { profileList = value;
            RaisePropertyChanged("ProfileList");
            }
        }
        
        private IndicatorEnum stringToIndicatorEnum(string value)
        {
            if (value == IndicatorEnum.Average.ToString())
                return IndicatorEnum.Average;

            if (value == IndicatorEnum.BollingerBand.ToString())
                return IndicatorEnum.BollingerBand;
            if (value == IndicatorEnum.MACD.ToString())
                return IndicatorEnum.MACD;
            if (value == IndicatorEnum.RSI.ToString())
                return IndicatorEnum.RSI;
            if (value == IndicatorEnum.Swing.ToString())
                return IndicatorEnum.Swing;

            return IndicatorEnum.Average;
        }

        #region Commands

        private RelayCommand add;
        public RelayCommand Add
        {
            get
            {
                return add ?? (add = new RelayCommand(() =>
                {
                   VisibleColumns.Add(SelectedColumn);
                    isAnythingChanged = true;
                }, () =>
                {
                    if (SelectedColumn != null && !VisibleColumns.Contains(SelectedColumn))
                        return true;
                    return false;
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
                    isAnythingChanged = true;

                    VisibleColumns.Remove(SelectedVisibleColumn);
                }, () =>
                {
                    if (!string.IsNullOrEmpty(SelectedVisibleColumn))
                        return true;
                    return false;
                }));
            }
        }

        private string activeProfile;

        public string ActiveProfile
        {
            get { return activeProfile; }
            set { activeProfile = value;
                  RaisePropertyChanged("ActiveProfile");

                if(value != null )
                {
                    var profile = IndicatorData.GetProfiles(stringToIndicatorEnum(SelectedIndicator)).FirstOrDefault(p=>p.Name == value);
                    VisibleColumns = new ObservableCollection<string>(profile.ColumnList);
                    SelectedFont = profile.font;
                    ProfileName = value;
                }
            }
        }


        private RelayCommand moveUp;
        public RelayCommand MoveUp
        {
            get
            {
                return moveUp ?? (moveUp = new RelayCommand(() =>
                {
                    var index = VisibleColumns.IndexOf(SelectedVisibleColumn);

                    if (index == 0) return;
                    isAnythingChanged = true;

                    var temp = selectedVisibleColumn;

                    VisibleColumns.Remove(SelectedVisibleColumn);
                    VisibleColumns.Insert(index - 1, temp);
                    SelectedVisibleColumn = temp;

                }, () =>
                {

                    if (!string.IsNullOrEmpty(SelectedVisibleColumn))
                        return true;
                    return false;
                }));
            }
        }

        private RelayCommand moveDown;
        public RelayCommand MoveDown
        {
            get
            {
                return moveDown ?? (moveDown = new RelayCommand(() =>
                {
                    var index = VisibleColumns.IndexOf(SelectedVisibleColumn);

                    if (index >= VisibleColumns.Count() - 1) return;

                    var temp = SelectedVisibleColumn;
                    isAnythingChanged = true;

                    VisibleColumns.Remove(SelectedVisibleColumn);
                    VisibleColumns.Insert(index + 1, temp);
                    SelectedVisibleColumn = temp;
                }, () =>
                {

                    if (!string.IsNullOrEmpty(SelectedVisibleColumn))
                        return true;
                    return false;
                }));
            }
        }


        bool isAnythingChanged = false;

        private RelayCommand save;
        public RelayCommand Save
        {
            get
            {
                return save ?? (save= new RelayCommand(() =>
                {
                    var profile = IndicatorData.GetProfiles(stringToIndicatorEnum(SelectedIndicator));
                    if (profile.FirstOrDefault(p => string.Compare(p.Name, profileName, true) == 0) == null)
                        profile.Add(new IndicatorProfile()
                            {
                                ColumnList = visibleColumns.ToList(),
                                font = selectedFont,
                                Name = ProfileName
                            });
                    else
                    {
                        var temp = profile.FirstOrDefault(p => string.Compare(p.Name, profileName, true) == 0);
                        temp.font = SelectedFont;
                        temp.ColumnList = VisibleColumns.ToList();
                    }

                    IndicatorData.ActiveProfiles[stringToIndicatorEnum(SelectedIndicator)] = profile.FirstOrDefault(p => string.Compare(p.Name, profileName, true) == 0);
                    IndicatorData.SerialiseActiveProfile();

                    HelperClasses.XMLHelper.writeXml(IndicatorData, STORAGEFILE);
                    MessageBox.Show("Profile saved successfully!!");
                    SelectedIndicator = Indicators.FirstOrDefault();
                }, () =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand cancel;
        public RelayCommand Cancel
        {
            get
            {
                return cancel ?? (cancel = new RelayCommand(() =>
                {
                    SelectedIndicator = Indicators.FirstOrDefault();

                }, () =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand selectFont;

        public RelayCommand SelectFont
        {
            get
            {
                return selectFont ?? (selectFont = new RelayCommand(() =>
                    {
                        var dig = new FontDialog();

                        if(dig.ShowDialog() != DialogResult.Cancel)
                        {
                            SelectedFont = dig.Font;
                        }
                    }));
            }
        }
        
        #endregion
    }
}
