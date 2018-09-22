using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathFunctionsProject
{
    public partial class FrmMathFunctions : Form
    {
        public FrmMathFunctions()
        {
            InitializeComponent();
        }

        public bool IsValidData()
        {
            return
                 IsDecimal(txtRightOperand, "Textbox Value") &&
                 IsNegNum(txtRightOperand, txtRightOperand.Text)&& 
                //if (check == "F!")
                // {
                IsWithinRange(txtRightOperand, txtRightOperand.Text, 0, 20);
               ///  }
               
               // else
                // {
               // IsWithinRange(txtRightOperand, txtRightOperand.Text, 0, 189);
           // }

         
        }

        public bool IsModulusValidData()
        {
            return
             IsDecimal2(txtLeftOperand, "LeftOperand", txtRightOperand, "RightOperand") &&
             IsNegNum2(txtLeftOperand, "LeftOperand", txtRightOperand, "RightOperand");
            // IsDecimal2 (txtLeftOperand, "LeftOperand", txtRightOperand, "RightOperand");
            // passing both operand values 
             
        }
        public bool IsNegNum2(TextBox txtLeftOperand, string lname, TextBox txtRightOperand, string rname)
        {
            lblMessage.Text = "";
            decimal dLeft;
            decimal dRight;
            dLeft = Convert.ToDecimal(txtLeftOperand.Text);
            dRight = Convert.ToDecimal(txtRightOperand.Text);

            if (dLeft < 0)
            {
                lblMessage.Text = lblMessage.Text + lname + " can't be a negative number." + "\n";
            }

            if (dRight < 0)
            {
                lblMessage.Text = lblMessage.Text + rname + " can't be a negative number." + "\n";
            }
            
            if (lblMessage.Text == "")
            {
                return true;
            }
            // found an error here
            else
            {
                return false;
            }
        }


        public bool IsDecimal2(TextBox txtLeftOperand, string lname, TextBox txtRightOperand, string rname)
        {
            lblMessage.Text = "";
            decimal rnumber = 0m;
            if (Decimal.TryParse(txtRightOperand.Text, out rnumber))
            {
               // return true;
            }
            else
            {
                lblMessage.Text = lblMessage.Text + rname + " must be a whole number value." + "\n\n";
                //return false;
              }
            decimal lnumber = 0m;
            if (Decimal.TryParse(txtLeftOperand.Text, out lnumber))
            {
                // return true;
            }
            else
            {
                lblMessage.Text = lblMessage.Text + lname + " must be a whole number value." + "\n\n";
                //return false;
            }
            if (lblMessage.Text == "")
            {
                return true;
            }
            // found an error here
            else
            {
                return false;
            }
                       
            if (lblMessage.Text == "")
            {

                return true;
            }
            // found an error here
            else
            {
                return false;
            }
        }

        public bool IsNegNum(TextBox textBox, string name)
        {
            lblMessage.Text = "";
            decimal dRight;
            dRight = Convert.ToDecimal(txtRightOperand.Text);

            if (dRight< 0)
            {
                lblMessage.Text = lblMessage.Text + name + " can't be a negative number." + "\n";
                return false;
            }
            return true;
       }
            public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                lblMessage.Text = (name + " must be a whole number value.");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textbox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text);

            if (number < min || number > max)

            {
                lblMessage.Text = ("Invalid range " + name + " must be between " + min + " and " + max + ".");
                textbox.Focus();
                return false; 
            }
            return true;
           }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShowFactorial_Click(object sender, EventArgs e)
        {
            txtRightOperand.Visible = true;
            txtLeftOperand.Visible = false;
            btnDoModulus.Enabled = false;
            btnDoFactorial.Enabled = true;
            btnDoFibonacci.Enabled = false;


            lblMessage.Text = "Find the Factorial of a number, enter a whole number in textbox";
        }

        

        private void btnDoModulus_Click(object sender, EventArgs e)
        {
            long lleft;
            long lright;
            long i;
            long fresult = 0;
            long total = 0;
            long remainder = 0;
            //Place Validation Here
            //Max number allowed is 20 and no negative numbers can be calculated. 

            if (IsModulusValidData())

            {
                lright = Convert.ToInt64(txtRightOperand.Text);
                lleft = Convert.ToInt64(txtLeftOperand.Text);
                i = lleft; 

                 while (i >= lright)
                {

                    fresult = i - lright;
                    if (fresult >= 0)
                    {
                        total = total + 1;
                    }

                     
                    i = fresult;
                    if (i <= lright)
                    {
                        if (i == 0)
                        {
                            remainder = fresult;
                        }
                        else
                        {
                            remainder = i;
                        }

                    }
                }

                lblMessage.Text = lleft.ToString() + " divided by " + lright.ToString() + " is " + total.ToString() + " with a remainder of " + remainder.ToString();
            }


               
        }
        
        private void btnShowModulus_Click(object sender, EventArgs e)
        {
            txtLeftOperand.Visible = true;
            txtRightOperand.Visible = true;
            btnDoModulus.Enabled = true;
            btnDoFactorial.Enabled = false;
            btnDoFibonacci.Enabled = false;

            lblMessage.Text = "Find the Modulus of a number, enter value of the number in the left text box for the dividend and the right text box for the divisor";
        }

        private void txtLeftOperand_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Text = "Thank you for using the MathFunction application";
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Cleaars Message Label
            lblMessage.Text = "";
        }

       

        private void btnShowFibonacci_Click(object sender, EventArgs e)
        {
            txtRightOperand.Visible = true;
            txtLeftOperand.Visible = false;
            btnDoModulus.Enabled = false;
            btnDoFactorial.Enabled = false;
            btnDoFibonacci.Enabled = true;

            lblMessage.Text = "Enter a whole number value to find the Fibonacci related value";
        }

        private void btnDoFactorial_Click(object sender, EventArgs e)
        {
            long uinput;
            long i;
            long fresult = 1;
           // string check = "F!";
            //Place Validation Here
            //Max number allowed is 20 and no negative numbers can be calculated. 

            if (IsValidData())
            {
                uinput = Convert.ToInt64(txtRightOperand.Text);

                for (i = uinput; i > 1; i--)
                {

                    fresult = fresult * i;
                }

                lblMessage.Text = "The answer to " + uinput + "!" + " is " + fresult.ToString("n0");
            }
        }

        private void btnDoFibonacci_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            long i = 0;
            long j = 1;
            long k = 0;
            long fib = 0;
            long fcal = 0;
            long fcal1 = 0;
            long[] pArray = new long[0];
            //long N;
            if (IsValidData())
            {

                long N = Convert.ToInt64(txtRightOperand.Text);

                for (i = 0; i < N; i++)
                {
                  //    lblMessage.Text = lblMessage.Text + "Fibonacci " + "(" + (i) + ")" + fib; 

                    fcal = j;
                    fib = j + k;
                    j = k;
                    fcal1 = k;
                    k = fib;
                  
                }
                             
                  lblMessage.Text = lblMessage.Text + "Fibonacci " + "(" + (i) + ")" + "=" + fcal.ToString() + "+" + fcal1.ToString() + "= " + fib.ToString();

               
            }









          



        }
      }
  }

   

