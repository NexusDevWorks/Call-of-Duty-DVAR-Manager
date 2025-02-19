using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using JRPC_Client;
using XDevkit;

namespace Cheat_Package_Manager
{
    public partial class Form1 : XtraForm
    {
        public static IXboxConsole jtag;
        private DataTable cheatCommands;

        private Dictionary<string, Action<IXboxConsole, string>> commandMapping = new Dictionary<string, Action<IXboxConsole, string>>()
        {
            { "Modern Warfare Multiplayer", MW.Cbuf_AddTextMP },
            { "World at War Multiplayer", WAW.Cbuf_AddTextMP },
            { "World at War Singleplayer", WAW.Cbuf_AddTextSP },
            { "Modern Warfare 2 Multiplayer", MW2.Cbuf_AddTextMP },
            { "Black Ops Multiplayer", BO.Cbuf_AddTextMP },
            { "Black Ops Singleplayer", BO.Cbuf_AddTextSP },
            { "Modern Warfare 3 Multiplayer", MW3.Cbuf_AddTextMP },
            { "Black Ops 2 Multiplayer", BO2.Cbuf_AddTextMP },
            { "Ghosts Multiplayer", Ghosts.Cbuf_AddTextMP }
        };

        public Form1()
        {
            InitializeComponent();

            codComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            codComboBox.Properties.Items.AddRange(new string[] {
                "Modern Warfare Multiplayer",
                "World at War Multiplayer",
                "World at War Singleplayer",
                "Modern Warfare 2 Multiplayer",
                "Black Ops Multiplayer",
                "Black Ops Singleplayer",
                "Modern Warfare 3 Multiplayer",
                "Black Ops 2 Multiplayer",
                "Ghosts Multiplayer"
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cheatCommands = new DataTable();
            cheatCommands.Columns.Add("Setting", typeof(string));
            cheatCommands.Columns.Add("Value", typeof(string));
            gridControl1.DataSource = cheatCommands;

            GridView gridView = gridControl1.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                gridView.RowUpdated += GridView_RowUpdated;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (jtag.Connect(out jtag, "default"))
            {
                XtraMessageBox.Show("Cheat Package Manager connected to Xbox 360",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Failed to connect.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            DataRow row = view.GetDataRow(e.RowHandle);
            if (row == null) return;

            string setting = row["Setting"]?.ToString().Trim();
            if (string.IsNullOrEmpty(setting))
                return;

            string value = row["Value"]?.ToString().Trim();

            string command = string.IsNullOrEmpty(value) ? setting : $"{setting} {value}";

            string selectedGame = codComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedGame))
            {
                XtraMessageBox.Show("Please select a game and mode from the dropdown.");
                return;
            }

            if (!commandMapping.TryGetValue(selectedGame, out Action<IXboxConsole, string> executeCommand))
            {
                XtraMessageBox.Show("Selected game/mode not supported.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (jtag == null)
            {
                XtraMessageBox.Show("Not connected to Xbox 360.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            executeCommand(jtag, command);
        }
        /* This button will add extra rows to the grid - add if you need it.
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataRow newRow = cheatCommands.NewRow();
            newRow["Setting"] = string.Empty;
            newRow["Value"] = string.Empty;
            cheatCommands.Rows.Add(newRow);
        }
        */
    }
}
