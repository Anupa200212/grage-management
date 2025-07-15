using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace supplier_management
{
    public partial class Form1 : Form
    {
        private Guna2Panel sidebar;
        private Guna2Panel header;
        private Guna2DataGridView supplierGrid;
        private Guna2Button addBtn, editBtn, removeBtn;
        private Label titleLabel;

        public Form1()
        {
            InitializeComponent();
            CreateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateUI()
        {
            this.Text = "Supplier Management";
            this.Size = new Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Sidebar Panel
            sidebar = new Guna2Panel();
            sidebar.FillColor = Color.FromArgb(23, 33, 43);
            sidebar.Size = new Size(220, this.Height);
            sidebar.Dock = DockStyle.Left;
            this.Controls.Add(sidebar);

            Label menuTitle = new Label();
            menuTitle.Text = "ALTIUM DXP";
            menuTitle.ForeColor = Color.FromArgb(0, 230, 255);
            menuTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            menuTitle.Location = new Point(20, 20);
            sidebar.Controls.Add(menuTitle);

            string[] menuItems = { "USER MANAGEMENT", "VAULT EXPLORER", "SUPPLIERS", "CONFIGURATION" };
            int y = 70;
            foreach (string item in menuItems)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = "   " + item;
                btn.ForeColor = Color.White;
                btn.FillColor = item == "SUPPLIERS" ? Color.FromArgb(0, 150, 136) : Color.FromArgb(34, 45, 55);
                btn.Size = new Size(200, 40);
                btn.TextAlign = HorizontalAlignment.Left;
                btn.Font = new Font("Segoe UI", 10);
                btn.Location = new Point(10, y);
                btn.BorderRadius = 5;
                btn.HoverState.FillColor = Color.FromArgb(0, 180, 160);
                sidebar.Controls.Add(btn);
                y += 45;
            }

            // Header Panel
            header = new Guna2Panel();
            header.FillColor = Color.White;
            header.Height = 100;
            header.Dock = DockStyle.Top;
            header.BorderColor = Color.LightGray;
            header.BorderThickness = 1;
            this.Controls.Add(header);

            titleLabel = new Label();
            titleLabel.Text = "User Management";
            titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titleLabel.Location = new Point(240, 20);
            titleLabel.ForeColor = Color.Black;
            header.Controls.Add(titleLabel);

            // Action Buttons (Right-Aligned)
            int buttonTop = 50;
            int spacing = 10;

            removeBtn = new Guna2Button();
            removeBtn.Text = "Remove";
            removeBtn.Size = new Size(90, 35);
            removeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeBtn.Location = new Point(this.ClientSize.Width - 240, buttonTop);
            removeBtn.FillColor = Color.White;
            removeBtn.BorderRadius = 6;
            removeBtn.BorderColor = Color.FromArgb(244, 67, 54);
            removeBtn.BorderThickness = 1;
            removeBtn.Font = new Font("Segoe UI", 9);
            removeBtn.ForeColor = Color.FromArgb(244, 67, 54);
            removeBtn.Click += RemoveBtn_Click;
            header.Controls.Add(removeBtn);

            editBtn = new Guna2Button();
            editBtn.Text = "Edit";
            editBtn.Size = new Size(80, 35);
            editBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editBtn.Location = new Point(removeBtn.Left - editBtn.Width - spacing, buttonTop);
            editBtn.FillColor = Color.White;
            editBtn.BorderRadius = 6;
            editBtn.BorderColor = Color.LightGray;
            editBtn.BorderThickness = 1;
            editBtn.Font = new Font("Segoe UI", 9);
            editBtn.ForeColor = Color.FromArgb(33, 37, 41);
            editBtn.Click += EditBtn_Click;
            header.Controls.Add(editBtn);

            addBtn = new Guna2Button();
            addBtn.Text = "Add User";
            addBtn.Size = new Size(100, 35);
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.Location = new Point(editBtn.Left - addBtn.Width - spacing, buttonTop);
            addBtn.FillColor = Color.FromArgb(0, 180, 216);
            addBtn.BorderRadius = 6;
            addBtn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            addBtn.ForeColor = Color.White;
            addBtn.Click += AddBtn_Click;
            header.Controls.Add(addBtn);

            // DataGridView
            supplierGrid = new Guna2DataGridView();
            supplierGrid.Location = new Point(230, 120);
            supplierGrid.Size = new Size(920, 500);
            supplierGrid.BackgroundColor = Color.White;
            supplierGrid.GridColor = Color.LightGray;
            supplierGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            supplierGrid.AllowUserToAddRows = true;
            supplierGrid.AllowUserToDeleteRows = true;
            supplierGrid.ReadOnly = false;
            supplierGrid.RowHeadersVisible = false;
            supplierGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 245, 245);
            supplierGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            supplierGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9);
            supplierGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 180, 216);
            supplierGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            supplierGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            supplierGrid.ColumnHeadersHeight = 35;

            supplierGrid.Columns.Add("Image", "Image");
            supplierGrid.Columns.Add("Username", "User Name");
            supplierGrid.Columns.Add("FirstName", "First Name");
            supplierGrid.Columns.Add("LastName", "Last Name");
            supplierGrid.Columns.Add("Email", "Email");
            supplierGrid.Columns.Add("Phone", "Phone");
            supplierGrid.Columns.Add("Domain", "Domain");

            foreach (DataGridViewColumn column in supplierGrid.Columns)
            {
                column.ReadOnly = false;
            }

            this.Controls.Add(supplierGrid);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            supplierGrid.Rows.Add();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Double click a cell to edit it directly.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (supplierGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in supplierGrid.SelectedRows)
                {
                    supplierGrid.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}