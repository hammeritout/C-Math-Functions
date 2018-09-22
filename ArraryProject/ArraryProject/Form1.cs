using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraryProject
{
    public partial class Form1 : Form
    {
        //Need to Initialize Array Here
        long[] GlobalArray;
        const int MAXARRAYSIZE = 5;

        public Form1()
        {
            InitializeComponent();
        }


        private void ClearOutTheArray(long[] ArrayToBeCleared, long ClearValue)
        {
            for (int lcv = 0; lcv < MAXARRAYSIZE; lcv++)
            {
                //Initialized
                ArrayToBeCleared[lcv] = ClearValue;

            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Build the Array
            GlobalArray = new long[MAXARRAYSIZE];
            for (int lcv = 0; lcv < MAXARRAYSIZE; lcv++)
            {
                //Initialized
                // GlobalArray[lcv] = -1;
                ClearOutTheArray(GlobalArray, -1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool KeepGoing = false;
            string ArrayDisplayContents = "";
            int index = 0;

            if (GlobalArray.Length > 0)
            {
                //Check index value
                if(GlobalArray[0] > 0)
                KeepGoing = true;
            }
             else
            {
                ArrayDisplayContents = "The Array is empty.";
            }
            while (KeepGoing)
            {

                ArrayDisplayContents += GlobalArray[index].ToString() + "\n";
                index++;
                if (index >= GlobalArray.Length)
                {
                    KeepGoing = false;
                }
                else
                {
                    if (GlobalArray[index] <= 0)
                    {
                        KeepGoing = false;
                    }
                }    
            }
            label3.Text = ArrayDisplayContents;
            ClearOutTheArray(GlobalArray, 199);

        }
    }
}
