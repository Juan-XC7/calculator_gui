using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculadora_GUI_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetInputItem(string item)
        {
            string currentValueText = displayBox.Text;
            string newValue = item.ToString();

            currentValueText += newValue;
            displayBox.Text = currentValueText;
        }

        private void number0_Click(object sender, EventArgs e)
        {
        SetInputItem("0");
        }

        private void number1_Click(object sender, EventArgs e)
        {
            SetInputItem("1");
        }

        private void number2_Click(object sender, EventArgs e)
        {
            SetInputItem("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetInputItem("3");
        }

        private void number4_Click(object sender, EventArgs e)
        {
            SetInputItem("4");
        }

        private void number5_Click(object sender, EventArgs e)
        {
            SetInputItem("5");
        }

        private void number6_Click(object sender, EventArgs e)
        {
            SetInputItem("6");
        }

        private void number7_Click(object sender, EventArgs e)
        {
            SetInputItem("7");
        }

        private void number8_Click(object sender, EventArgs e)
        {
            SetInputItem("8");
        }

        private void number9_Click(object sender, EventArgs e)
        {
            SetInputItem("9");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string GetOperator()
        {
            char[] operators = { '+', '-', '/', '*' };
            string currentValueText = displayBox.Text;

            foreach (char op in operators)
            {
                if (currentValueText.Contains(op))
                {
                    return op.ToString();
                }
            }

            return "";
        }
        private bool SearchForOperators()
        {
            string[] operators = { "+", "-", "/", "*" };
            string currentValueText = displayBox.Text;

            foreach (string op in operators)
            {
                if (currentValueText.Contains(op))
                {
                    return true;
                }
            }

            return false;
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            bool hasOperator = SearchForOperators();
            if (!hasOperator) {
                SetInputItem("+");
            }
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            bool hasOperator = SearchForOperators();
            if (!hasOperator)
            {
                SetInputItem("-");
            }
        }

        private void timesButton_Click(object sender, EventArgs e)
        {
            bool hasOperator = SearchForOperators();
            if (!hasOperator)
            {
                SetInputItem("*");
            }
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            bool hasOperator = SearchForOperators();
            if (!hasOperator)
            {
                SetInputItem("/");
            }
        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            string currentValueText = displayBox.Text;

            if (!currentValueText.Contains("."))
            {
                SetInputItem(".");
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            double result = 0;
            string input = displayBox.Text;

            bool hasOperator = SearchForOperators();

            if (displayBox.TextLength < 3)
            {
                MessageBox.Show("There must be at least 3 characters", "Invalid length", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!hasOperator)
            {
                MessageBox.Show("You must select an operation", "Invalid operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Char.IsDigit(displayBox.Text[0]) || !Char.IsDigit(displayBox.Text[displayBox.TextLength - 1]))
            {
                MessageBox.Show("The first and last characters must be numbers", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Find the index of the operator
                int operatorIndex = input.IndexOfAny(new char[] { '+', '-', '*', '/' });

                if (operatorIndex != -1)
                {
                    // Extract the first number
                    string firstNumberString = input.Substring(0, operatorIndex);
                    int firstNumber = int.Parse(firstNumberString);

                    // Extract the second number
                    string secondNumberString = input.Substring(operatorIndex + 1);
                    int secondNumber = int.Parse(secondNumberString);

                    // Extract the operator
                    char op = input[operatorIndex];
                    switch (op)
                    {
                        case '+':
                            result = firstNumber + secondNumber;
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            break;
                        case '*':
                            result = firstNumber * secondNumber;
                            break;
                        case '/':
                            if (secondNumber != 0)
                            {
                                result = firstNumber / secondNumber;
                            }
                            else
                            {
                                // Handle divide by zero case
                                MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Exit the method without setting the result
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid operator");
                            break;
                    }


                    displayBox.Text = result.ToString();
                }
            else
            {
                // Handle case when no operator is found
                Console.WriteLine("No operator found in the input.");
            }
        }

        private string DeleteLastChar(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 0)
            {
                // Handle empty or null string
                return input;
            }
            else
            {
                return input.Substring(0, input.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayBox.Text = DeleteLastChar(displayBox.Text);
        }
    }
}