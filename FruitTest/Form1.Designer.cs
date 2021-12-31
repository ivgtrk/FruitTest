namespace FruitTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_acceptance = new System.Windows.Forms.Button();
            this.bt_report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_acceptance
            // 
            this.bt_acceptance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_acceptance.Location = new System.Drawing.Point(12, 12);
            this.bt_acceptance.Name = "bt_acceptance";
            this.bt_acceptance.Size = new System.Drawing.Size(249, 48);
            this.bt_acceptance.TabIndex = 0;
            this.bt_acceptance.Text = "Приемка таваров";
            this.bt_acceptance.UseVisualStyleBackColor = true;
            this.bt_acceptance.Click += new System.EventHandler(this.bt_acceptance_Click);
            // 
            // bt_report
            // 
            this.bt_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_report.Location = new System.Drawing.Point(12, 75);
            this.bt_report.Name = "bt_report";
            this.bt_report.Size = new System.Drawing.Size(249, 48);
            this.bt_report.TabIndex = 1;
            this.bt_report.Text = "Отчет";
            this.bt_report.UseVisualStyleBackColor = true;
            this.bt_report.Click += new System.EventHandler(this.bt_report_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 138);
            this.Controls.Add(this.bt_report);
            this.Controls.Add(this.bt_acceptance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_acceptance;
        private System.Windows.Forms.Button bt_report;
    }
}

