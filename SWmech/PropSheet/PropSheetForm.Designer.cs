
namespace SWmech.PropSheet
{
    partial class PropSheetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.FormatsComboBox = new System.Windows.Forms.ComboBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VerticalRadioButton = new System.Windows.Forms.RadioButton();
            this.HorizontalRadioButton = new System.Windows.Forms.RadioButton();
            this.MultiplicityComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Формат:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ширина:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Висота:";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(209, 154);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 24);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Скасувати";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(209, 124);
            this.OkButton.Margin = new System.Windows.Forms.Padding(2);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 24);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "Ок";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // FormatsComboBox
            // 
            this.FormatsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatsComboBox.FormattingEnabled = true;
            this.FormatsComboBox.Location = new System.Drawing.Point(82, 7);
            this.FormatsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FormatsComboBox.Name = "FormatsComboBox";
            this.FormatsComboBox.Size = new System.Drawing.Size(92, 21);
            this.FormatsComboBox.TabIndex = 7;
            this.FormatsComboBox.SelectedValueChanged += new System.EventHandler(this.FormatsComboBox_SelectedValueChanged);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(82, 56);
            this.WidthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.ReadOnly = true;
            this.WidthTextBox.Size = new System.Drawing.Size(92, 20);
            this.WidthTextBox.TabIndex = 8;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(82, 79);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.ReadOnly = true;
            this.HeightTextBox.Size = new System.Drawing.Size(92, 20);
            this.HeightTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Кратність:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VerticalRadioButton);
            this.groupBox1.Controls.Add(this.HorizontalRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(162, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оріентація";
            // 
            // VerticalRadioButton
            // 
            this.VerticalRadioButton.AutoSize = true;
            this.VerticalRadioButton.Location = new System.Drawing.Point(4, 41);
            this.VerticalRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.VerticalRadioButton.Name = "VerticalRadioButton";
            this.VerticalRadioButton.Size = new System.Drawing.Size(102, 19);
            this.VerticalRadioButton.TabIndex = 1;
            this.VerticalRadioButton.TabStop = true;
            this.VerticalRadioButton.Text = "Вертикальна";
            this.VerticalRadioButton.UseVisualStyleBackColor = true;
            // 
            // HorizontalRadioButton
            // 
            this.HorizontalRadioButton.AutoSize = true;
            this.HorizontalRadioButton.Location = new System.Drawing.Point(4, 19);
            this.HorizontalRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.HorizontalRadioButton.Name = "HorizontalRadioButton";
            this.HorizontalRadioButton.Size = new System.Drawing.Size(115, 19);
            this.HorizontalRadioButton.TabIndex = 0;
            this.HorizontalRadioButton.TabStop = true;
            this.HorizontalRadioButton.Text = "Горизонтальна";
            this.HorizontalRadioButton.UseVisualStyleBackColor = true;
            // 
            // MultiplicityComboBox
            // 
            this.MultiplicityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MultiplicityComboBox.FormattingEnabled = true;
            this.MultiplicityComboBox.Location = new System.Drawing.Point(82, 31);
            this.MultiplicityComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MultiplicityComboBox.Name = "MultiplicityComboBox";
            this.MultiplicityComboBox.Size = new System.Drawing.Size(92, 21);
            this.MultiplicityComboBox.TabIndex = 13;
            // 
            // PropSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 188);
            this.Controls.Add(this.MultiplicityComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.FormatsComboBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropSheetForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметри аркуша";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ComboBox FormatsComboBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton VerticalRadioButton;
        private System.Windows.Forms.RadioButton HorizontalRadioButton;
        private System.Windows.Forms.ComboBox MultiplicityComboBox;
    }
}