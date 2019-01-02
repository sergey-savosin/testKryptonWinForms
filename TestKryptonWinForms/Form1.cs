using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKryptonWinForms
{
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private const int SCLEX_MSSQL = 55;
        private const int SCE_MSSQL_DEFAULT = 0;
        private const int SCE_MSSQL_COMMENT = 1;
        private const int SCE_MSSQL_LINE_COMMENT = 2;
        private const int SCE_MSSQL_NUMBER = 3;
        private const int SCE_MSSQL_STRING = 4;
        private const int SCE_MSSQL_OPERATOR = 5;
        private const int SCE_MSSQL_IDENTIFIER = 6;
        private const int SCE_MSSQL_VARIABLE = 7;
        private const int SCE_MSSQL_COLUMN_NAME = 8;
        private const int SCE_MSSQL_STATEMENT = 9;
        private const int SCE_MSSQL_DATATYPE = 10;
        private const int SCE_MSSQL_SYSTABLE = 11;
        private const int SCE_MSSQL_GLOBAL_VARIABLE = 12;
        private const int SCE_MSSQL_FUNCTION = 13;
        private const int SCE_MSSQL_STORED_PROCEDURE = 14;
        private const int SCE_MSSQL_DEFAULT_PREF_DATATYPE = 15;
        private const int SCE_MSSQL_COLUMN_NAME_2 = 16;
        private const int SCE_MSSQL_LINE_NUMBER = 33;

        ScintillaNET.Scintilla scintillaTextBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // CREATE CONTROL
            scintillaTextBox = new ScintillaNET.Scintilla();
            kryptonGroup2.Panel.Controls.Add(scintillaTextBox);

            // BASIC CONFIG
            scintillaTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            //scintillaTextBox.TextChanged += (this.OnTextChanged);

            // INITIAL VIEW CONFIG
            scintillaTextBox.WrapMode = WrapMode.None;
            scintillaTextBox.IndentationGuides = IndentView.LookBoth;

            // STYLING
            InitColors();
            scintillaTextBox.Lexer = (Lexer)SCLEX_MSSQL;

            InitSyntaxColoring(isDarkTheme: true);

            scintillaTextBox.Text = getSampleSqlText();
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitColors()
        {
            scintillaTextBox.SetSelectionBackColor(true, IntToColor(0x114D9C));
        }

        private void InitSyntaxColoring(bool isDarkTheme)
        {
            // Configure the default style

            if (isDarkTheme)
            {
                scintillaTextBox.StyleResetDefault();
                scintillaTextBox.Styles[Style.Default].Font = "Consolas";
                scintillaTextBox.Styles[Style.Default].Size = 10;
                scintillaTextBox.Styles[Style.Default].BackColor = IntToColor(0x2B2B2B);
                scintillaTextBox.Styles[Style.Default].ForeColor = Color.Teal;
            }
            else
            {
                scintillaTextBox.StyleResetDefault();
                scintillaTextBox.Styles[Style.Default].Font = "Courier New";
                scintillaTextBox.Styles[Style.Default].Size = 10;
            }

            // Set the SQL Lexer
            //scintillaTextBox.Lexer = Lexer.Sql;
            scintillaTextBox.Lexer = (Lexer)SCLEX_MSSQL;
            // Show line numbers
            scintillaTextBox.Margins[0].Width = 20;
            scintillaTextBox.Margins[0].BackColor = Color.Green;
            scintillaTextBox.Margins[1].BackColor = Color.Green;

            //scintillaTextBox.LexerLanguage = "mssql";

            if (isDarkTheme)
            {
                scintillaTextBox.StyleClearAll();
                // Configure the SQL lexer styles
                scintillaTextBox.Styles[Style.Default].BackColor = IntToColor(0x2B2B2B);
                scintillaTextBox.Styles[Style.Default].ForeColor = Color.Teal;
                scintillaTextBox.Styles[SCE_MSSQL_LINE_NUMBER].BackColor = IntToColor(0x2B2B2B);
                scintillaTextBox.Styles[SCE_MSSQL_LINE_NUMBER].ForeColor = Color.LightGray;

                scintillaTextBox.Styles[SCE_MSSQL_IDENTIFIER].ForeColor = IntToColor(0xA9B7C6);
                scintillaTextBox.Styles[SCE_MSSQL_COMMENT].ForeColor = IntToColor(0x808080);
                scintillaTextBox.Styles[SCE_MSSQL_LINE_COMMENT].ForeColor = IntToColor(0x808080);
                scintillaTextBox.Styles[SCE_MSSQL_NUMBER].ForeColor = IntToColor(0x6897BB);
                scintillaTextBox.Styles[SCE_MSSQL_STRING].ForeColor = IntToColor(0x6A8759);
                scintillaTextBox.Styles[SCE_MSSQL_OPERATOR].ForeColor = IntToColor(0xE0E0E0);
                // word 0
                scintillaTextBox.Styles[SCE_MSSQL_STATEMENT].ForeColor = IntToColor(0x92CC43);
                // ?
                scintillaTextBox.Styles[SCE_MSSQL_COLUMN_NAME].ForeColor = IntToColor(0x9876AA);
                // ?
                scintillaTextBox.Styles[SCE_MSSQL_COLUMN_NAME_2].ForeColor = IntToColor(0x9876AA);
                // word 2
                scintillaTextBox.Styles[SCE_MSSQL_DATATYPE].ForeColor = IntToColor(0x769AA5);
                // user 1
                scintillaTextBox.Styles[SCE_MSSQL_FUNCTION].ForeColor = IntToColor(0xFFC66D);
                scintillaTextBox.Styles[SCE_MSSQL_GLOBAL_VARIABLE].ForeColor = Color.Blue;
            }
            else
            {
                scintillaTextBox.StyleClearAll();
                // Set the Styles
                scintillaTextBox.Styles[Style.LineNumber].ForeColor = Color.FromArgb(255, 128, 128, 128);  //Dark Gray
                scintillaTextBox.Styles[Style.LineNumber].BackColor = Color.FromArgb(255, 228, 228, 228);  //Light Gray
                scintillaTextBox.Styles[Style.Sql.Comment].ForeColor = Color.Green;
                scintillaTextBox.Styles[Style.Sql.CommentLine].ForeColor = Color.Green;
                scintillaTextBox.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.Green;
                scintillaTextBox.Styles[Style.Sql.Number].ForeColor = Color.Maroon;
                scintillaTextBox.Styles[Style.Sql.Word].ForeColor = Color.Blue;
                scintillaTextBox.Styles[Style.Sql.SqlPlusPrompt].ForeColor = Color.Blue;
                scintillaTextBox.Styles[Style.Sql.Word2].ForeColor = Color.Fuchsia;
                scintillaTextBox.Styles[Style.Sql.User1].ForeColor = Color.Gray;
                scintillaTextBox.Styles[Style.Sql.User2].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green
                //scintillaTextBox.Styles[Style.Sql.String].ForeColor = Color.Red;
                scintillaTextBox.Styles[Style.Sql.Character].ForeColor = Color.Red;
                scintillaTextBox.Styles[Style.Sql.Operator].ForeColor = Color.Black;
            }

            // Set keyword lists
            // Word = 0
            scintillaTextBox.SetKeywords(0, @"add alter as authorization backup begin bigint binary bit break browse bulk by cascade case catch check checkpoint close clustered column commit compute constraint containstable continue create current cursor cursor database date datetime datetime2 datetimeoffset dbcc deallocate decimal declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor float for foreign freetext freetexttable from full function goto grant group having hierarchyid holdlock identity identity_insert identitycol if image index insert int intersect into key kill lineno load merge money national nchar nocheck nocount nolock nonclustered ntext numeric nvarchar of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext real reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select set setuser shutdown smalldatetime smallint smallmoney sql_variant statistics table table tablesample text textsize then time timestamp tinyint to top tran transaction trigger truncate try union unique uniqueidentifier update updatetext use user values varbinary varchar varying view waitfor when where while with writetext xml go ");
            // Word2 = 1
            scintillaTextBox.SetKeywords(1, @"ascii cast char charindex ceiling coalesce collate contains convert current_date current_time current_timestamp current_user floor isnull max min nullif object_id session_user substring system_user tsequal ltrim rtrim trim schema_name");
            // User1 = 4
            scintillaTextBox.SetKeywords(4, @"all and any between cross exists in inner is join left like not null or outer pivot right some unpivot ( ) * ");
            // User2 = 5
            scintillaTextBox.SetKeywords(5, @"sys objects sysobjects ");
        }

        string getSampleSqlText()
        {
            return Resource1.sampleSqlText;
        }

        private void btLightScheme_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = kryptonPalette_Office2010_Blue;
            treeView1.StateCommon.Back.Color1 = Color.Empty;
            treeView1.StateCommon.Node.Content.ShortText.Color1 = Color.Black;
            treeView1.StateCommon.Node.Back.Color1 = Color.PaleGreen;

            kryptonHeaderGroup2.Palette = kryptonPalette_Office2010_Blue;

            InitSyntaxColoring(isDarkTheme: false);
        }

        private void btDarkScheme_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = kryptonPalette_Office2010_Black;
            treeView1.StateCommon.Back.Color1 = Color.DimGray;
            treeView1.StateCommon.Node.Content.ShortText.Color1 = Color.White;
            treeView1.StateCommon.Node.Back.Color1 = Color.RoyalBlue;

            kryptonHeaderGroup2.Palette = kryptonPalette_Office2010_Black;
            kryptonHeaderGroup2.Panel.BackColor = Color.DimGray;
            kryptonHeaderGroup2.Panel.ForeColor = Color.Red;

            InitSyntaxColoring(isDarkTheme: true);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("One");
            treeView1.Nodes.Add(node);
            var r = new Random(10);
            int iMax = r.Next(10);
            string str = "";
            TreeNode lastSubNode = node;
            for (int i = 0; i < iMax; i++)
            {
                str = str + "next word " + i.ToString();
                if (r.Next(2) == 1)
                {
                    TreeNode tmpNode = new TreeNode(str);
                    lastSubNode.Nodes.Add(tmpNode);
                    lastSubNode = tmpNode;
                }

            }
            TreeNode node3 = new TreeNode(str);
            node.Nodes.Add(node3);
        }

    }
}
