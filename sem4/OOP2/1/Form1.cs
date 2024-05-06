namespace _1
{
    public partial class Form1 : Form
    {

        private Calculator Calc;
        public Form1()
        {
            InitializeComponent();
            Calc = new Calculator(InputField);
            Calc.ValueChange += UpdateValue;
        }

        private void UpdateValue(double newVal)
        {
            InputField.Text = newVal.ToString();
        }


        private void InputField_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox input = (TextBox)sender;

                if (input == null)
                {
                    throw new CustomException("Missing sender object!");
                }

                if (double.TryParse(input.Text, out double result))
                {
                    Calc.Value = result;
                }
                else 
                { 
                    throw new CustomException("NaN detected at Input");
                }

            }
            catch (CustomException error)
            {
                Calc.Notify();
                Console.WriteLine(error.Message1);
            }
            catch (Exception error) {
                Calc.Notify();
                Console.WriteLine(error.Message);
            }
            finally
            {
                Console.WriteLine("Ну я не придумал =)");
            }
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            Calc.Sin();
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            Calc.Cos();
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            Calc.Tan();
        }

        private void CtgButton_Click(object sender, EventArgs e)
        {
            Calc.Ctg();
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            Calc.Sqrt();
        }

        private void CbrtButton_Click(object sender, EventArgs e)
        {
            Calc.Cbrt();
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            Calc.Square();
        }

        private void CubeButton_Click(object sender, EventArgs e)
        {
            Calc.Cube();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Calc.Reset();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Calc.Memorize();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            Calc.Paste();
        }
    }
}
