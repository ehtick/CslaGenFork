using System;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using System.IO;
using System.Xml.Serialization;

namespace CslaGenerator.Controls
{
    public partial class ProjectProperties : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ProjectProperties()
        {
            InitializeComponent();
            DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            FillComboBox(cboOutputLanguage, typeof(CodeLanguage));
            FillComboBox(cboTarget, typeof(TargetFramework));
            FillComboBox(cboTargetDAL, typeof(TargetDAL));
            cboTargetDAL.Items.RemoveAt(4);
            cboTargetDAL.Items.RemoveAt(3);
            FillComboBox(cboGenerateAuthorization, typeof(Authorization));
            FillComboBox(cboHeaderVerbosity, typeof(HeaderVerbosity));
            FillComboBox(cboTransactionType, typeof(TransactionType));
            FillComboBox(cboPersistenceType, typeof(PersistenceType));
            FillComboBox(cboCreateTimestampPropertyMode, typeof(PropertyDeclaration));
            FillComboBox(cboCreateReadOnlyObjectsPropertyMode, typeof(PropertyDeclaration));
            foreach (TabPage tab in tabControlMain.TabPages)
                foreach (Control ctl in tab.Controls)
                    foreach (Binding b in ctl.DataBindings)
                        b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            txtIntSoftDelete.Enabled = false;
            chkGenerateInlineQueries.Enabled = false;
            chkUseBypassPropertyChecks.Enabled = false;
        }

        private void FillComboBox(ComboBox cbo, Type enumType)
        {
            foreach (string str in Enum.GetNames(enumType))
            {
                cbo.Items.Add(str);
            }
            cbo.Tag = enumType;
            cbo.DataBindings[0].Parse += EnumDropDownParse;
        }

        private void EnumDropDownParse(object sender, ConvertEventArgs e)
        {
            Binding binding = (Binding)sender;
            ComboBox cbo = (ComboBox)binding.Control;
            Type t = (Type)cbo.Tag;
            e.Value = Enum.Parse(t, e.Value.ToString());

        }

        private CslaGeneratorUnit mProject
        {
            get
            {
                return GeneratorController.Current.CurrentUnit;
            }
        }

        private GenerationParameters _genParams;
        private ProjectParameters _projParams;

        public void LoadInfo()
        {
            _genParams = mProject.GenerationParams.Clone();
            _projParams = mProject.Params.Clone();
            generationParametersBindingSource.DataSource = _genParams;
            projectParametersBindingSource.DataSource = _projParams;
        }

        public void SaveInfo()
        {
            if (_genParams.Dirty)
                mProject.GenerationParams = _genParams.Clone();
            if (_projParams.Dirty)
                mProject.Params = _projParams.Clone();
            LoadInfo();
        }

        private void CmdApplyClick(object sender, EventArgs e)
        {
            if (!ValidateOptions())
                return;

            DialogResult confirm = DialogResult.No;
            if (!(_projParams.SpGeneralPrefix.Equals(mProject.Params.SpGeneralPrefix) &&
                _projParams.SpGetPrefix.Equals(mProject.Params.SpGetPrefix) &&
                _projParams.SpAddPrefix.Equals(mProject.Params.SpAddPrefix) &&
                _projParams.SpUpdatePrefix.Equals(mProject.Params.SpUpdatePrefix) &&
                _projParams.SpDeletePrefix.Equals(mProject.Params.SpDeletePrefix) &&
                _projParams.SpGeneralSuffix.Equals(mProject.Params.SpGeneralSuffix) &&
                _projParams.SpGetSuffix.Equals(mProject.Params.SpGetSuffix) &&
                _projParams.SpAddSuffix.Equals(mProject.Params.SpAddSuffix) &&
                _projParams.SpUpdateSuffix.Equals(mProject.Params.SpUpdateSuffix) &&
                _projParams.SpDeleteSuffix.Equals(mProject.Params.SpDeleteSuffix)))
            {
                confirm = MessageBox.Show(@"Your SP headings have changed. Do you wish to update your business objects to reflect these changes?", @"SP Naming", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            SaveInfo();
            GeneratorController.Current.ReloadPropertyGrid();
            if (confirm == DialogResult.Yes)
            {
                foreach (CslaObjectInfo info in mProject.CslaObjects)
                {
                    info.SetProcedureNames();
                }
            }
        }

        private void CmdUndoClick(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void CmdExportClick(object sender, EventArgs e)
        {
            OpenFileDialog fileSave = new OpenFileDialog();
            fileSave.Title = @"Export project settings - Select an existing file or type a new file name";
            fileSave.Filter = @"CSLA Gen files (*.xml) | *.xml";
            fileSave.DefaultExt = "xml";
            fileSave.Multiselect = false;
            fileSave.CheckFileExists = false;
            fileSave.CheckPathExists = true;
            fileSave.AddExtension = true;
            DialogResult result = fileSave.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            Application.DoEvents();
            ExportParams(fileSave.FileName);
        }

        private void CmdGetDefaultClick(object sender, EventArgs e)
        {
            ImportParams(Application.CommonAppDataPath + @"\Default.xml");
        }

        private void CmdSetDefaultClick(object sender, EventArgs e)
        {
            ExportParams(Application.CommonAppDataPath + @"\Default.xml");
        }

        private void CmdResetToFactoryClick(object sender, EventArgs e)
        {
            ImportParams(Application.StartupPath + @"\Factory.xml");
        }

        private void CmdImportClick(object sender, EventArgs e)
        {
            var fileLoad = new OpenFileDialog();
            fileLoad.Title = @"Import project settings - Select an existing file";
            fileLoad.Filter = @"CSLA Gen files (*.xml) | *.xml";
            fileLoad.DefaultExt = "xml";
            fileLoad.CheckFileExists = true;
            fileLoad.CheckPathExists = true;
            fileLoad.Multiselect = false;
            var result = fileLoad.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            Application.DoEvents();
            ImportParams(fileLoad.FileName);
        }

        private void ImportParams(string filename)
        {
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            CslaGeneratorUnit unit;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    var s = new XmlSerializer(typeof(CslaGeneratorUnit));
                    unit = (CslaGeneratorUnit)s.Deserialize(fs);
                }
                if (unit != null)
                {
                    mProject.Params = unit.Params;
                    mProject.GenerationParams = unit.GenerationParams;
                    LoadInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to import: " + Environment.NewLine + ex.Message, @"Import Error");
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        public void ExportParams(string fileName)
        {
            if (!ApplyProjectProperties())
                return;

            var privateUnit = new CslaGeneratorUnit();
            privateUnit.GenerationParams = _genParams.Clone();
            privateUnit.Params = _projParams.Clone();
            FileStream fs = null;
            string tempFile = Path.GetTempPath() + Guid.NewGuid() + ".cslagenerator";
            bool success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                XmlSerializer s = new XmlSerializer(typeof(CslaGeneratorUnit));
                s.Serialize(fs, privateUnit);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error occurred while trying to export: " + Environment.NewLine + ex.Message, @"Export Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                fs.Close();
            }

            if (success)
            {
                File.Delete(fileName);
                File.Move(tempFile, fileName);
            }
        }

        private void GenerationParametersBindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            if (IsDirty)
                TabText = @"Project Properties*";
            else
                TabText = @"Project Properties";

            if (UseCsla4)
            {
                if (cboTargetDAL.Items[0].ToString() == "None")
                    cboTargetDAL.Items.RemoveAt(0);

                chkActiveObjects.Checked = false;
                chkSynchronous.Enabled = !_genParams.ForceSyncUI;
                chkAsynchronous.Enabled = !_genParams.ForceAsyncUI;
            }
            else
            {
                if (cboTargetDAL.Items[0].ToString() != "None")
                    cboTargetDAL.Items.Insert(0, TargetDAL.None);

                chkWinForms.Checked = true;
                chkWPF.Checked = false;
                chkSilverlight.Checked = false;
                chkSynchronous.Checked = true;
                chkAsynchronous.Checked = false;

                chkSynchronous.Enabled = false;
                chkAsynchronous.Enabled = false;
            }

            cboTargetDAL.Enabled = UseDal;
            chkGenerateDAL.Enabled = UseDal;
            txtDALNamespace.Enabled = UseDal;
            txtInterfaceDALNamespace.Enabled = UseDal;

            chkWinForms.Enabled = UseCsla4;
            chkWPF.Enabled = UseCsla4;
            chkSilverlight.Enabled = UseCsla4;
            chkActiveObjects.Enabled = !UseCsla4;
        }

        public bool IsDirty
        {
            get
            {
                return (_genParams.Dirty || _projParams.Dirty);
            }
        }

        private bool UseCsla4
        {
            get
            {
                return (_genParams.UseCsla4);
            }
        }

        private bool UseDal
        {
            get
            {
                return (_genParams.UseDal);
            }
        }

        internal bool ApplyProjectProperties()
        {
            if (IsDirty)
            {
                DialogResult result = MessageBox.Show(@"There are unsaved changes in the project properties tab. Would you like to apply them now?", @"CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        cmdApply.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        internal bool ValidateOptions()
        {
            var result = true;
            if (!_genParams.GenerateAsynchronous && !_genParams.GenerateSynchronous)
            {
                result = false;
                MessageBox.Show(@"Must select either Synchronous or Asynchronous server methods.", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!_genParams.GenerateWinForms && !_genParams.GenerateWPF)
            {
                result = false;
                MessageBox.Show(@"Must select either Windows Forms or WPF.", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}