namespace CompSci.zClasswork.Tests;

public class Form1 : Form
{
    private Label lblInput, lblFrom, lblTo;
    private TextBox txtInput, txtResult;
    private ComboBox cmbFrom, cmbTo;
    private Button btnConvert;

    public Form1()
    {
        this.Text = "Number Converter";
        this.Width = 400;
        this.Height = 300;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Input label and textbox
        lblInput = new Label { Text = "Input:", Top = 20, Left = 20, AutoSize = true };
        txtInput = new TextBox { Top = 20, Left = 100, Width = 250 };
        this.Controls.Add(lblInput);
        this.Controls.Add(txtInput);

        // From label and combo
        lblFrom = new Label { Text = "From:", Top = 60, Left = 20, AutoSize = true };
        cmbFrom = new ComboBox { Top = 60, Left = 100, Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbFrom.Items.AddRange(new string[] { "Decimal", "Binary", "Hexadecimal", "Octal" });
        cmbFrom.SelectedIndex = 0;
        this.Controls.Add(lblFrom);
        this.Controls.Add(cmbFrom);

        // To label and combo
        lblTo = new Label { Text = "To:", Top = 100, Left = 20, AutoSize = true };
        cmbTo = new ComboBox { Top = 100, Left = 100, Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTo.Items.AddRange(new string[] { "Decimal", "Binary", "Hexadecimal", "Octal" });
        cmbTo.SelectedIndex = 1;
        this.Controls.Add(lblTo);
        this.Controls.Add(cmbTo);

        // Convert button
        btnConvert = new Button { Text = "Convert", Top = 140, Left = 100, Width = 100 };
        btnConvert.Click += BtnConvert_Click;
        this.Controls.Add(btnConvert);

        // Result textbox
        txtResult = new TextBox { Top = 180, Left = 100, Width = 250, ReadOnly = true };
        this.Controls.Add(txtResult);
    }

    private void BtnConvert_Click(object sender, EventArgs e)
    {
        try
        {
            string input = txtInput.Text.Trim();
            string from = cmbFrom.SelectedItem.ToString();
            string to = cmbTo.SelectedItem.ToString();

            // Convert input to integer
            int number = from switch
            {
                "Decimal" => int.Parse(input),
                "Binary" => Convert.ToInt32(input, 2),
                "Hexadecimal" => Convert.ToInt32(input, 16),
                "Octal" => Convert.ToInt32(input, 8),
                _ => throw new Exception("Unknown base")
            };

            // Convert to target base
            string result = to switch
            {
                "Decimal" => number.ToString(),
                "Binary" => Convert.ToString(number, 2),
                "Hexadecimal" => Convert.ToString(number, 16).ToUpper(),
                "Octal" => Convert.ToString(number, 8),
                _ => throw new Exception("Unknown base")
            };

            txtResult.Text = result;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Invalid input: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}