using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningAhead2Kml
{
    public partial class RA2KmlForm : Form
    {
        List<WorkoutGroup> workoutGroupStyles = new List<WorkoutGroup>();
        int defaultLineWeight = 4;
        int defaultOpacityPercent = 60;
        Color defaultColor = Color.FromArgb(55, 45, 255);
        RunningAheadFileProcessing raData = new RunningAheadFileProcessing();

        public RA2KmlForm()
        {
            InitializeComponent();
            opacitySlider.Value = defaultOpacityPercent;
            opacityValue.Text = defaultOpacityPercent.ToString();
            opacityValue.Text = opacitySlider.Value.ToString();
            opacitySlider.Scroll += opacitySlider_Scroll;
            opacityValue.TextChanged += opacityValue_TextChanged;
            colorPreview.BackColor = defaultColor;
            lineWidth.Value = defaultLineWeight;
        }

        //Step 1: user chooses a file to upload
        private void selectDataFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                openFileName.Text = openFileDialog.FileName;
                outputMessages.Text = "Opening selected file...";
                if (checkInputFile())
                {
                    openFileName.Text = openFileDialog.FileName;
                    outputMessages.Text = "";
                    //convertButton.Enabled = true;
                    selectFileNext.Enabled = true;
                }
                else
                {
                    outputMessages.Text = "* Error reading XML file - please choose another file.";
                }
            }
        }

        //Step 2: User clicks Next on the wizard
        private void selectFileNext_Click(object sender, EventArgs e)
        {
            if (checkInputFile())
            {
                outputMessages.Text = "please wait...";
                try
                {
                    raData.ImportXmlLogFile(openFileName.Text);
                }
                catch (Exception ex)
                {
                    outputMessages.Text = "* Error reading XML file - please choose a valid RunningAhead.com log file.\n" + ex.Message;
                    return;
                }
                List<string> allWorkoutCombos = raData.IdentifyUniqueWorkoutCombos(openFileName.Text);
                //RunningAheadFileProcessing.ConvertXmlToKml(openFileName.Text);
                outputMessages.Text = "";

                //populate radio button list
                int i = 0;
                int listSpacing = ComputeListSpacing(allWorkoutCombos.Count);
                foreach (String combo in allWorkoutCombos)
                {
                    RadioButton comboButton = new RadioButton();
                    comboButton.Text = combo;
                    comboButton.Top = combosPanel.Top + (i * listSpacing);
                    comboButton.CheckedChanged += radioButton1_CheckedChanged;
                    if (i == 0)
                    {
                        comboButton.Checked = true;
                    }
                    combosPanel.Controls.Add(comboButton);
                    workoutGroupStyles.Add(new WorkoutGroup(combo, defaultLineWeight, defaultColor, defaultOpacityPercent, true));
                    i++;
                }
                selectFilePanel.Visible = false;
            }
            else
            {
                outputMessages.Text = "* Error reading XML file - please choose a valid RunningAhead.com log file.";
            }
        }

        private Boolean checkInputFile()
        {
            string inputFile = openFileName.Text;
            try
            {
                string fileContents = File.ReadAllText(inputFile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int ComputeListSpacing(int itemCount)
        {
            if (itemCount > 12)
            {
                return 20;
            }
            else if (itemCount > 8)
            {
                return 25;
            }
            else
            {
                return 30;
            }
        }
        
        
        //Step 3: User edits the default styles for the output KML
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton senderRadio = (RadioButton)sender;
            if (senderRadio.Checked == false)
            {
                //save the workoutListStyles with the styles of the currently chosen styles
                int i = -1;
                foreach (Control control in combosPanel.Controls)
                {
                    if (control is RadioButton)
                    {
                        i++;
                        if (control.Text == senderRadio.Text)
                        {
                            //save settings from previously selected item
                            SaveWorkoutStyle(i);
                            break;
                        }
                    }
                }
                
            }
            else
            {
                //load settings for newly selected item from workoutListStyles
                int i = -1;
                foreach (Control control in combosPanel.Controls)
                {
                    if (control is RadioButton)
                    {
                        i++;
                        RadioButton radio = (RadioButton)control;
                        if (radio.Checked)
                        {
                            LoadSavedWorkoutGroup(i);
                            break;
                        }
                    }
                }
            }
        }

        private void SaveLastWorkoutStyle()
        {
            int i = -1;
            foreach (Control control in combosPanel.Controls)
            {
                if (control is RadioButton)
                {
                    i++;
                    RadioButton selectedRadioButton = (RadioButton)control;
                    if (selectedRadioButton.Checked)
                    {
                        SaveWorkoutStyle(i);
                        break;
                    }
                }
            }
        }

        private void SaveWorkoutStyle(int i)
        {
            workoutGroupStyles[i].exportGroup = exportThisGroup.Checked;
            int opacity = defaultOpacityPercent;
            int.TryParse(opacityValue.Text, out opacity);
            //int opacityFull = (int)Math.Round((opacity * 2.55), 0);
            workoutGroupStyles[i].opacityPercent = opacity;
            workoutGroupStyles[i].lineColor = colorPreview.BackColor;
            workoutGroupStyles[i].lineWeight = (int)lineWidth.Value;
        }

        private void LoadSavedWorkoutGroup(int i)
        {
            exportThisGroup.Checked = workoutGroupStyles[i].exportGroup;
            opacityValue.Text = workoutGroupStyles[i].opacityPercent.ToString();
            opacitySlider.Value = workoutGroupStyles[i].opacityPercent;
            colorPreview.BackColor = workoutGroupStyles[i].lineColor;
            lineWidth.Value = workoutGroupStyles[i].lineWeight;
        }

        private void opacityValue_TextChanged(object sender, EventArgs e)
        {
            int newValue = defaultOpacityPercent;
            if (int.TryParse(opacityValue.Text, out newValue))
            {
                opacitySlider.Value = newValue;
            }
        }

        private void opacitySlider_Scroll(object sender, EventArgs e)
        {
            opacityValue.Text = opacitySlider.Value.ToString();
        }

        private void colorPreview_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = colorPreview.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorPreview.BackColor = colorDialog.Color;
            }
        }



        //Step 5: User initiates the file conversion process
        private void convertButton_Click(object sender, EventArgs e)
        {
            //Save any changes to active style category
            SaveLastWorkoutStyle();

            //Pass the workoutGroups List to the next function and create the output file
            raData.StyleWorkoutGroups(workoutGroupStyles);

            if (!string.IsNullOrEmpty(saveKmlLocation.Text))
            {
                string saveLocation = saveKmlLocation.Text;
                if (!saveLocation.ToLower().EndsWith(".kml") && !saveLocation.ToLower().EndsWith(".kmz"))
                {
                    saveLocation += ".kml";
                }
                raData.ExportTransformedXmlToKml(saveLocation, workoutGroupStyles);
            }
            else
            {
                outputMessages.Text = "Choose a location to save your output file";
            }

        }

        



        //UI - Wizard navigation
        private void previous_Click(object sender, EventArgs e)
        {
            selectFilePanel.Visible = true;
        }

        private void RA2KmlForm_Load(object sender, EventArgs e)
        {

        }

        //Step 4: User chooses where to save the output KML file
        private void saveKmlAsButton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveKmlFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                saveKmlLocation.Text = saveKmlFileDialog.FileName;
                convertButton.Enabled = true;
            }
        }

    }
}
