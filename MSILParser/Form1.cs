using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics.SymbolStore;




namespace MSILParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblResults.Text = "";
                int n = Convert.ToInt32(numericUpDown1.Value);
                
                // Parse the expression and build our dynamic method
                MsilParser em = new MsilParser();
                Type t = em.CompileMsil(textBox1.Text);
                
                // Get a typed delegate reference to our method. This is very 
                // important for quick efficient calls!
                MethodInfo m = t.GetMethod("RunExpression");
                Delegate d = Delegate.CreateDelegate(typeof(MsilParser.ExpressionInvoker<Object>), m);
                MsilParser.ExpressionInvoker<Object> method = (MsilParser.ExpressionInvoker<Object>)d;
 
                // Start the timer
                Object result = null;
                Stopwatch st = new Stopwatch();
                st.Start();

                // Make a call to the method N-times
                for (int i = 0; i < n; i++)
                {
                    result = method();
                }

                // Stop the timer and output results
                st.Stop();
                lblResults.Text = ("Expression Value: " + result.ToString() + "\n" +
                    "Evaluation Time: " + st.Elapsed.ToString() + "\n") +
                    "Number of Iterations: " + n;

                // Save the Assembly and generate the MSIL code with ILDASM.EXE
                string modName = "expression.dll";
                Process p = new Process();
                p.StartInfo.FileName = "ildasm.exe";
                p.StartInfo.Arguments = "/text /nobar \"" + modName;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();

                string s = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                txtMsil.Text = s;

            }
            catch (Exception ex)
            {
                lblResults.Text = "Could not parse: \n"+ex.Message;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                btnParse.Enabled = false;
            else
                btnParse.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    
    
    
    
    
    }
}
