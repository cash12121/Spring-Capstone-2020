using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for frameTrainingVideos.xaml
    /// </summary>
    public partial class frameTrainingVideos : Page
    {
        private TrainingVideo _trainingVideo;
        private TrainingVideoVM _trainingVideoVM;
        private bool _editMode = false;
        bool _insertMode = false;
        private ITrainingVideoManager _videoManager = new TrainingVideoManager();


        public frameTrainingVideos()
        {
            InitializeComponent();
        }



        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver:
        /// 
        /// This method is called when the view training videos tab is selected in the PM canvas
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabTrainingVideos_GotFocus(object sender, RoutedEventArgs e)
        {
            populateActiveVideoList(chkVideosActive.IsChecked.Value);
            dgVideoList.Columns.RemoveAt(0);
        }



        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver:
        /// 
        /// Helper method to populate the data grid
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schutle
        /// Updated: 04/29
        /// CHANGE: added parameter isWatched
        /// 
        /// </remarks>
        private void populateVideoList(bool isWatched = false)
        {
            dgVideoList.ItemsSource = _videoManager.RetrieveTrainingVideosByEmployee(isWatched);
        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver: Jordan Lindo
        /// 
        /// Event handler for the Add button
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/03/2020
        /// CHANGE: Added boolean insert mode and edit mode
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVideo_Click(object sender, RoutedEventArgs e)
        {
            _trainingVideo = null;
            _editMode = true;
            _insertMode = true;
            showPrompt();
            txtVideoID.IsReadOnly = false;
            txtRunTimeM.Text = "";
            txtRunTimeS.Text = "";
            txtVideoDesc.Text = "";
            txtVideoID.Text = "";
            chkVideoActive.IsChecked = true;
            chkVideoActive.IsEnabled = false;
        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver: Jordan Lindo
        /// 
        /// Helper method for showing the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01/2020
        /// CHANGE: Added edit mode if/else, show checkbox for sorting by active, hide checkbox for deactivating/activating videos
        /// 
        /// </remarks>

        private void showPrompt()
        {
            canViewVideos.Visibility = Visibility.Hidden;

            canAdd.Visibility = Visibility.Visible;
            if (_editMode == true)
            {
                txtVideoID.IsReadOnly = false;
                txtRunTimeM.IsReadOnly = false;
                txtRunTimeS.IsReadOnly = false;
                txtVideoDesc.IsReadOnly = false;
                chkVideoActive.IsEnabled = true;
            }
            else if (_editMode == false)
            {
                txtVideoID.IsReadOnly = true;
                txtRunTimeM.IsReadOnly = true;
                txtRunTimeS.IsReadOnly = true;
                txtVideoDesc.IsReadOnly = true;
                chkVideoActive.IsEnabled = false;
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver: Jordan Lindo
        /// 
        /// Event handler for the Save button
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01/2020
        /// CHANGE: Added update mode functionality
        /// 
        /// Updater: Alex Diers
        /// Updated: 4/7/20
        /// CHANGE: Added update to modify the IsWatched field
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveVideo_Click(object sender, RoutedEventArgs e)
        {
            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = txtVideoID.Text;
            newVideo.RunTimeMinutes = Convert.ToInt32(txtRunTimeM.Text);
            newVideo.RunTimeSeconds = Convert.ToInt32(txtRunTimeS.Text);
            newVideo.Description = txtVideoDesc.Text;
            if (_insertMode == true)
            {
                try
                {
                    bool result = _videoManager.InsertTrainingVideo(newVideo);
                    if (result)
                    {
                        MessageBox.Show("Video Added.");
                        hidePrompt();
                        populateActiveVideoList(chkVideosActive.IsChecked.Value);
                    }
                    else
                    {
                        MessageBox.Show("Video Not Added.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Video failed to save." + ex.Message);
                }
            }
            if (_insertMode == false)
            {
                try
                {
                    bool result = _videoManager.EditTrainingVideo(_trainingVideo, newVideo);
                    if (result)
                    {
                        //try
                        //{
                        //    if (chkIsWatched.IsChecked.Value == false)
                        //    {
                        //        _videoManager.EditNotWatched(_trainingVideoVM);
                        //    }
                        //    else
                        //    {
                        //        _videoManager.EditIsWatched(_trainingVideoVM);
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Failed to change Watched field");
                        //}
                        MessageBox.Show("Video Modified.");
                        hidePrompt();
                        populateActiveVideoList(chkVideosActive.IsChecked.Value);
                    }
                    else
                    {
                        MessageBox.Show("Video Not Added.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Video failed to save." + ex.Message);
                }
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver: Jordan Lindo
        /// 
        /// Helper method to hide the Add/Edit form on the page
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/03/2020
        /// CHANGE: Added Hide for Actie for datagrid checkbox and Edit button for  
        /// 
        /// </remarks>
        private void hidePrompt()
        {
            canAdd.Visibility = Visibility.Hidden;
            canViewVideos.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 2/20/2020
        /// Approver:
        /// 
        /// Event handler for the Cancel button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            hidePrompt();
        }

        private void DgVideoList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgVideoList.ItemsSource == null)
                {
                    populateActiveVideoList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Edit a specific video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/06/2020
        /// Update: Added visibility not visible for datagrid
        /// Updater: Alex Diers
        /// Updated: 4/7/20
        /// CHANGE: Set view model for training video for edit
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditVideo_Click(object sender, RoutedEventArgs e)
        {
            if (dgVideoList.SelectedItem != null)
            {
                _editMode = true;
                _insertMode = false;
                _trainingVideo = (TrainingVideo)dgVideoList.SelectedItem;

                showPrompt();
                txtVideoID.IsReadOnly = true;
                txtRunTimeM.Text = _trainingVideo.RunTimeMinutes.ToString();
                txtRunTimeS.Text = _trainingVideo.RunTimeSeconds.ToString();
                txtVideoDesc.Text = _trainingVideo.Description.ToString();
                txtVideoID.Text = _trainingVideo.TrainingVideoID.ToString();
                chkVideoActive.IsChecked = _trainingVideo.Active;
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a video");
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// View a specific video
        /// </summary>
        ///
        /// <remarks>
        /// Updater : Chase Schutle
        /// Updated: 5/2/20
        /// Update: Added check to see if video slected exists
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewVideo_Click(object sender, RoutedEventArgs e)
        {
            if (dgVideoList.SelectedItem != null)
            {
                _trainingVideoVM = (TrainingVideoVM)dgVideoList.SelectedItem;
                if (_trainingVideoVM.IsWatched == false)
                {
                    _videoManager.EditIsWatched(_trainingVideoVM);
                }
                else
                {
                    _videoManager.EditNotWatched(_trainingVideoVM);
                }

                populateVideoList(chkToggleWatchedVideos.IsChecked.Value);
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a video");
            }


        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Activate/Deactivate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkVideoActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(bool)chkVideoActive.IsChecked)
                {
                    _videoManager.DeactivateTrainingVideo(_trainingVideo);
                    populateActiveVideoList(chkVideosActive.IsChecked.Value);

                }
                else if ((bool)chkVideoActive.IsChecked)
                {
                    _videoManager.ActivateTrainingVideo(_trainingVideo);
                    populateActiveVideoList(chkVideosActive.IsChecked.Value);
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.ToString());
            }
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Sort by active/inactive videos
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Alex Diers
        /// Updated: 5/1/20
        /// Update: Uses different helper method due to refactoring of the previous one it used
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkVideosActive_Click(object sender, RoutedEventArgs e)
        {
            populateActiveVideoList(chkVideosActive.IsChecked.Value);


            if (chkVideosActive.IsChecked == false)
            {
                lblActiveVideos.Content = "Inactive";
            }
            else
            {
                lblActiveVideos.Content = "Active";
            }

        }

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 04/29/2020
        /// Approver: Chase Schulte
        /// 
        /// Event handler for clicking the Watched checkbox
        /// </summary>
        /// 
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 05/01/2020
        /// Update: Change btn content to reflect chk box
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkToggleWatchedVideos_Click(object sender, RoutedEventArgs e)
        {
            populateVideoList(chkToggleWatchedVideos.IsChecked.Value);
            if (chkToggleWatchedVideos.IsChecked.Value == true)
            {
                btnViewVideo.Content = "Mark as Unviewed";
            }
            else
            {
                btnViewVideo.Content = "Mark as Viewed";
            }
        }



        /// <summary>
        /// Creator: Alex Diers
        /// Created: 04/29/2020
        /// Approver: Chase Schulte
        /// 
        /// Event handler for the Sort by Employee checkbox
        /// </summary>
        /// 
        /// <remarks>
        /// Updater : Alex Diers
        /// Updated:4/30/20
        /// Update: Changed visibility of certain fields based on relevancy
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSort_Click(object sender, RoutedEventArgs e)
        {
            if (chkSort.IsChecked.Value == false)
            {
                populateActiveVideoList(chkVideosActive.IsChecked.Value);
                lblToggleWatchedVideos.Visibility = Visibility.Hidden;
                chkToggleWatchedVideos.Visibility = Visibility.Hidden;
                btnViewVideo.Visibility = Visibility.Hidden;
                lblActiveVideos.Visibility = Visibility.Visible;
                chkVideosActive.Visibility = Visibility.Visible;
            }
            else
            {
                populateVideoList(chkToggleWatchedVideos.IsChecked.Value);
                lblToggleWatchedVideos.Visibility = Visibility.Visible;
                chkToggleWatchedVideos.Visibility = Visibility.Visible;
                btnViewVideo.Visibility = Visibility.Visible;
                lblActiveVideos.Visibility = Visibility.Hidden;
                chkVideosActive.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// NAME : Alex Diers
        /// Created: 5/1/2020
        /// Approver:Chase Schulte
        /// 
        /// Helper method for sorting by active and inactive videos
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        private void populateActiveVideoList(bool active = true)
        {
            dgVideoList.ItemsSource = _videoManager.RetrieveTrainingVideosByActive(active);
        }
    }
}
