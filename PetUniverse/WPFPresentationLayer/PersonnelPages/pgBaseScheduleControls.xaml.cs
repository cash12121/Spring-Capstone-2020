using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for BaseScheduleControls.xaml
    /// </summary>
    public partial class BaseScheduleControls : Page
    {
        IDepartmentManager _departmentManager;
        IShiftTimeManager _shiftTimeManager;
        IERoleManager _eRoleManager;
        IBaseScheduleManager _baseScheduleManager;
        PetUniverseUser _user;
        BaseScheduleVM _baseScheduleVM;
        List<BaseScheduleLine> _lines;
        List<BaseScheduleLine> _dGLines;
        List<BaseScheduleLine> _newLines;
        List<string> _departmentNames;
        int _maxCount;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a constructor method that takes no arguments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public BaseScheduleControls()
        {
            InitializeComponent();
            _baseScheduleManager = new BaseScheduleManager();
            _departmentManager = new DepartmentManager();
            _shiftTimeManager = new ShiftTimeManager();
            _eRoleManager = new ERoleManager();
            _dGLines = new List<BaseScheduleLine>();
            _user = new PetUniverseUser();
            _departmentNames = getDepartmentNames();
            cboDepartment.ItemsSource = _departmentNames;
            getBaseScheduleVM();
            canBaseSchedule.Visibility = Visibility.Visible;
            canEditBaseSchedule.Visibility = Visibility.Hidden;
            _maxCount = 30;

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a constructor method that takes a PUUser.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="user"></param>
        public BaseScheduleControls(PetUniverseUser user)
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
            _baseScheduleManager = new BaseScheduleManager();
            _shiftTimeManager = new ShiftTimeManager();
            _eRoleManager = new ERoleManager();
            _dGLines = new List<BaseScheduleLine>();
            getBaseScheduleVM();
            canBaseSchedule.Visibility = Visibility.Visible;
            canEditBaseSchedule.Visibility = Visibility.Hidden;
            _maxCount = 30;
            _user = user;
            _departmentNames = getDepartmentNames();
            cboDepartment.ItemsSource = _departmentNames;
            setNewLines();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a method gets the active base schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void getBaseScheduleVM()
        {
            try
            {
                _baseScheduleVM = _baseScheduleManager.GetActiveBaseSchedule();
                if (null != _baseScheduleVM)
                {
                    _lines = _baseScheduleVM.BaseScheduleLines;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
            }
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This creates as list of department name strings.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        private List<string> getDepartmentNames()
        {
            List<string> names = new List<string>();
            try
            {
                foreach (Department department in _departmentManager.RetrieveAllDepartments())
                {
                    names.Add(department.DepartmentID);
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
            }
            if (names.Count == 0)
            {
                names.Add("None Available.");
            }

            return names;
        }
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This fills the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setDataGird();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a method for removing unnecessary columns
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 3/18/2020
        /// Update: Removed foreach to modify col width and added column headers.
        /// 
        /// Updater: Jordan Lindo
        /// Updated: 3/19/2020
        /// Update: Removed hard coded headers removed unneccessary columns.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgBaseSchedule_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgBaseSchedule.Columns.RemoveAt(3);
            dgBaseSchedule.Columns.RemoveAt(3);
            dgBaseSchedule.Columns.RemoveAt(3);
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/30/2020
        /// Approver: Chase Schulte
        /// 
        /// This is the method for cancel button click.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            canEditBaseSchedule.Visibility = Visibility.Hidden;
            canBaseSchedule.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/30/2020
        /// Approver: Chase Schulte
        /// 
        /// This gets a list of base schedule lines by department and matches the count to the previous base schedul if the line existed.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="department"></param>
        /// <returns></returns>
        private List<BaseScheduleLine> getBaseScheduleLinesByDepartment(string department)
        {

            List<BaseScheduleLine> oldLines = _lines;
            List<BaseScheduleLine> lines = new List<BaseScheduleLine>();
            try
            {
                List<PetUniverseShiftTime> times =
                    _shiftTimeManager.RetrieveShiftTimesByDepartment(department);
                List<ERole> roles =
                    _eRoleManager.RetrieveERolesByDepartmentID(department);

                foreach (PetUniverseShiftTime time in times)
                {
                    foreach (ERole role in roles)
                    {

                        lines.Add(new BaseScheduleLineVM()
                        {
                            BaseScheduleID = 0,
                            Count = 0,
                            DepartmentID = department,
                            ERoleID = role.ERoleID,
                            ShiftTimeID = time.ShiftTimeID,
                            StartTime = time.StartTime,
                            EndTime = time.EndTime
                        });
                    }
                }
                if (null != oldLines)
                {
                    foreach (BaseScheduleLine line in lines)
                    {
                        foreach (BaseScheduleLine oldLine in oldLines)
                        {
                            if (line.ERoleID.Equals(oldLine.ERoleID)
                                && line.ShiftTimeID.Equals(oldLine.ShiftTimeID))
                            {
                                line.Count = oldLine.Count;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
            }
            return lines;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/30/2020
        /// Approver: Chase Schulte
        /// 
        /// This is used to aggrigate a list of base schedule lines for the new base schedule.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        private void setNewLines()
        {
            _newLines = new List<BaseScheduleLine>();
            foreach (string department in _departmentNames)
            {
                List<BaseScheduleLine> lines;
                try
                {
                    lines = getBaseScheduleLinesByDepartment(department);
                }
                catch (Exception)
                {
                    throw;
                }
                foreach (BaseScheduleLine line in lines)
                {
                    _newLines.Add(line);
                }
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// This displays the edit canvas with appropriate informaion.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditCount_Click(object sender, RoutedEventArgs e)
        {
            if (dgBaseSchedule.SelectedIndex != -1)
            {
                BaseScheduleLine line = (BaseScheduleLine)dgBaseSchedule.SelectedItem;
                lblDepartmentName.Content = line.DepartmentID;
                lblRoleName.Content = line.ERoleID;
                fillCount();
                cboCount.SelectedIndex = line.Count;
                canBaseSchedule.Visibility = Visibility.Hidden;
                canEditBaseSchedule.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// This fills the count combobox.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        private void fillCount()
        {
            for (int i = 0; i <= _maxCount; i++)
            {
                cboCount.Items.Add(i);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// This saves the changes made to a temporary list.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BaseScheduleLine selected = (BaseScheduleLine)dgBaseSchedule.SelectedItem;
            bool done = false;
            for (int i = 0; i < _newLines.Count && !done; i++)
            {

                if (_newLines.ElementAt(i).ShiftTimeID.Equals(selected.ShiftTimeID) && _newLines.ElementAt(i).ERoleID.Equals(selected.ERoleID))
                {
                    _newLines.ElementAt(i).Count = cboCount.SelectedIndex;
                    done = true;
                }
            }
            WPFErrorHandler.SuccessMessage(selected.ERoleID + " count set to " + cboCount.SelectedIndex);
            setDataGird();
            canEditBaseSchedule.Visibility = Visibility.Hidden;
            canBaseSchedule.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// This is used to set the data grid.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        private void setDataGird()
        {
            if (cboDepartment.SelectedIndex > -1)
            {
                List<BaseScheduleLineVM> lines = new List<BaseScheduleLineVM>();
                foreach (BaseScheduleLineVM item in _newLines)
                {
                    if (item.DepartmentID.Equals(cboDepartment.SelectedItem))
                    {
                        lines.Add(item);
                    }
                }
                dgBaseSchedule.ItemsSource = lines;
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// this resets the data to the active base schedule and clears the temporary list.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            setNewLines();
            setDataGird();
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/1/2020
        /// Approver: Chase Schulte
        /// 
        /// This stores the changes in the data store.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetBaseSchedule_Click(object sender, RoutedEventArgs e)
        {
            BaseScheduleVM newBaseScheduleVM = new BaseScheduleVM
            {
                BaseScheduleLines = _newLines,
                CreatingUserID = _user.PUUserID,
                CreationDate = DateTime.Now
            };
            try
            {
                _baseScheduleManager.AddBaseSchedule(newBaseScheduleVM);
                getBaseScheduleVM();
                WPFErrorHandler.SuccessMessage("Base Schedule Added.");
                setNewLines();
                setDataGird();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Schedule not added. " + ex.Message);
            }
        }
    }
}
