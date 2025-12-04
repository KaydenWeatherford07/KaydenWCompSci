namespace Enviroment1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        lbl_Play = new System.Windows.Forms.Label();
        lbl_Score = new System.Windows.Forms.Label();
        lbl_Time = new System.Windows.Forms.Label();
        lbl_Message = new System.Windows.Forms.Label();
        lbl_HighScore = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lbl_Play
        // 
        lbl_Play.BackColor = System.Drawing.SystemColors.ControlText;
        lbl_Play.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lbl_Play.ForeColor = System.Drawing.Color.DarkKhaki;
        lbl_Play.Location = new System.Drawing.Point(12, 72);
        lbl_Play.Margin = new System.Windows.Forms.Padding(0);
        lbl_Play.Name = "lbl_Play";
        lbl_Play.Size = new System.Drawing.Size(500, 500);
        lbl_Play.TabIndex = 0;
        lbl_Play.Text = resources.GetString("lbl_Play.Text");
        lbl_Play.Click += lbl_Play_Click;
        // 
        // lbl_Score
        // 
        lbl_Score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lbl_Score.Font = new System.Drawing.Font("Segoe UI", 11F);
        lbl_Score.Location = new System.Drawing.Point(12, 9);
        lbl_Score.Name = "lbl_Score";
        lbl_Score.Size = new System.Drawing.Size(142, 52);
        lbl_Score.TabIndex = 1;
        lbl_Score.Text = "Score:\r\n0\r\n";
        lbl_Score.Click += label2_Click;
        // 
        // lbl_Time
        // 
        lbl_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lbl_Time.Font = new System.Drawing.Font("Segoe UI", 11F);
        lbl_Time.Location = new System.Drawing.Point(370, 9);
        lbl_Time.Name = "lbl_Time";
        lbl_Time.Size = new System.Drawing.Size(142, 52);
        lbl_Time.TabIndex = 2;
        lbl_Time.Text = "Time:\r\n0";
        lbl_Time.Click += lbl_Time_Click;
        // 
        // lbl_Message
        // 
        lbl_Message.BackColor = System.Drawing.SystemColors.ControlDark;
        lbl_Message.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lbl_Message.ForeColor = System.Drawing.Color.DarkOrchid;
        lbl_Message.Location = new System.Drawing.Point(144, 242);
        lbl_Message.Name = "lbl_Message";
        lbl_Message.Size = new System.Drawing.Size(227, 140);
        lbl_Message.TabIndex = 3;
        lbl_Message.Text = "Press Enter To Start New Game!";
        lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lbl_Message.Click += lbl_Start_Click;
        // 
        // lbl_HighScore
        // 
        lbl_HighScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lbl_HighScore.Font = new System.Drawing.Font("Segoe UI", 11F);
        lbl_HighScore.Location = new System.Drawing.Point(191, 9);
        lbl_HighScore.Name = "lbl_HighScore";
        lbl_HighScore.Size = new System.Drawing.Size(142, 52);
        lbl_HighScore.TabIndex = 4;
        lbl_HighScore.Text = "High Score:\r\n0\r\n";
        lbl_HighScore.Click += lbl_HighScore_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(520, 586);
        Controls.Add(lbl_HighScore);
        Controls.Add(lbl_Message);
        Controls.Add(lbl_Time);
        Controls.Add(lbl_Score);
        Controls.Add(lbl_Play);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbl_HighScore;

    private System.Windows.Forms.Label lbl_Message;

    private System.Windows.Forms.Label lbl_Play;

    private System.Windows.Forms.Label lbl_Score;

    private System.Windows.Forms.Label lbl_Time;

    #endregion
}