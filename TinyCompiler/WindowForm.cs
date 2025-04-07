using System.Windows.Forms;

namespace TinyCompiler
{
    public partial class WindowForm : Form
    {
        public WindowForm()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, System.EventArgs e)
        {
            string sourceCode = tfSourceCode.Text;
            Compiler.Compile(sourceCode);

            PrintTokensTable();
            PrintParseTree();
            PrintErrors();
        }

        private void PrintTokensTable()
        {
            tblTokens.Rows.Clear();
            foreach (var token in Compiler.tinyo_Scannero.Tokens)
            {
                tblTokens.Rows.Add(token.lex, token.type);
            }
        }

        private void PrintErrors()
        {
            tfErrors.Clear();
            foreach (var error in Errors.Error_List)
            {
                tfErrors.Text += error + "\r\n";
            }
        }

        private void PrintParseTree()
        {
            treePrase.Nodes.Clear();
            treePrase.Nodes.Add(PrintParaseTree(Compiler.treeo_Rooto));
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            // Resest UI Elements
            tfSourceCode.Clear();
            tfErrors.Clear();
            tblTokens.Rows.Clear();
            treePrase.Nodes.Clear();

            // Reset Global Data
            Compiler.Tokeno_Streamo.Clear();
            Errors.Error_List.Clear();
        }

        private static TreeNode PrintParaseTree(Node root)
        {
            TreeNode tree = new TreeNode("Parse Tree");
            TreeNode treeRoot = PrintTree(root);

            if (treeRoot != null)
            {
                tree.Nodes.Add(treeRoot);
            }

            return tree;
        }

        private static TreeNode PrintTree(Node root)
        {
            if ((root == null) || (root.Name == null))
            {
                return null;
            }

            TreeNode tree = new TreeNode(root.Name);
            foreach (Node child in root.Children)
            {
                if (child == null)
                {
                    continue;
                }

                tree.Nodes.Add(PrintTree(child));
            }

            return tree;
        }
    }
}
