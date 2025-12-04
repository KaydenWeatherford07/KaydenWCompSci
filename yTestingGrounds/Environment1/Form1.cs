namespace Enviroment1;
using System.Windows.Forms;
public partial class Form1 : Form
{
    private Timer timer;
    
    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        
        timer = new Timer();
        timer.Interval = 1000; // milliseconds (1 second)
    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            lbl_Play.Text = "Test";
        }
        else if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private void lbl_Play_Click(object sender, EventArgs e)
    {
        return;
    }

    private void lbl_Start_Click(object sender, EventArgs e)
    {
        return;
    }

    private void label2_Click(object sender, EventArgs e)
    {
        return;
    }

    private void lbl_HighScore_Click(object sender, EventArgs e)
    {
        return;
    }

    private void lbl_Time_Click(object sender, EventArgs e)
    {
        return;
    }
}