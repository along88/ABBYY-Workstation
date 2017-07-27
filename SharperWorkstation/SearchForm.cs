using SharperWorkstation;
using SharperWorkstation.WorkstationModels;
using SharperWorkstation.WorkstationPresenter;
using SharperWorkstation.WorkstationView;
using System;
using System.Windows.Forms;

namespace SharperWorkstation
{
    public partial class SearchForm : CustomForm, ISearchView
    {
        
        public SearchForm()
        {
            this.Controls.Add(dgViewSOV);
            InitializeComponent();
            


        }

        public string ControlNo
        {

            get { return txtControlNo.Text; }

            set { txtControlNo.Text = value; }
        }

        public object Grid
        {
            get {return dgViewSOV.DataSource;}
            set { dgViewSOV.DataSource = value; }
        }

        public Panel EditPanel
        {
            get;
            set;
        }

        public event EventHandler<EventArgs> EditClicked;
        public event EventHandler<EventArgs> onStateChanged;
        public event EventHandler<EventArgs> onFormLoad;

        private void txtControlNo_TextChanged(object sender , EventArgs e)
        {
            
            TextBox txtBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(txtBox.Text))
            {
                
                onStateChanged(this, e);

            }

        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            EditClicked(this, e);
            this.Controls.Remove(dgViewSOV);
            ControlNum = ControlNo;
            onFormLoad(this, e);
            for (int i = 0; i < dgViewSOV.Columns.Count; i++)
            {
                dgViewSOV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
    }
}
