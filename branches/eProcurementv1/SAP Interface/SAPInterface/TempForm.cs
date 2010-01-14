using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SAPInterface
{
	/// <summary>
	/// Summary description for TempForm.
	/// </summary>
	public class TempForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private RetrieveMaterialRequirement xdata;

		public TempForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			xdata = new RetrieveMaterialRequirement();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataGrid
			// 
			this.DataGrid.DataMember = "";
			this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DataGrid.Location = new System.Drawing.Point(16, 72);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.Size = new System.Drawing.Size(512, 168);
			this.DataGrid.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(144, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "Delete";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// TempForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.ClientSize = new System.Drawing.Size(560, 266);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "TempForm";
			this.Text = "TempForm";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TempForm());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
//			xdata.GetRejectionDetails();
//			xdata.UpdateRejectControlDate();
//			xdata.GetRequirementDetails();	
//			RetrieveContract retrieveContract = new RetrieveContract();
//			retrieveContract.GetContractDetails();
//			DataTable aTable = xdata.GetMaterialRequirement().ToADODataTable();
//			DataGrid.DataSource = aTable;

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
//			ClearPurchaseData clearData = new ClearPurchaseData();
//			clearData.ClearContractData();
		}
	}
}
