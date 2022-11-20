
namespace Graph
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_Out = new System.Windows.Forms.Button();
            this.cmd = new System.Windows.Forms.Label();
            this.CB_Example = new System.Windows.Forms.ComboBox();
            this.L_ArrayOfA = new System.Windows.Forms.Label();
            this.CB_Transform = new System.Windows.Forms.ComboBox();
            this.B_Transform = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Out
            // 
            this.B_Out.Location = new System.Drawing.Point(240, 447);
            this.B_Out.Name = "B_Out";
            this.B_Out.Size = new System.Drawing.Size(132, 38);
            this.B_Out.TabIndex = 0;
            this.B_Out.Text = "вывести";
            this.B_Out.UseVisualStyleBackColor = true;
            this.B_Out.Click += new System.EventHandler(this.B_Out_Click);
            // 
            // cmd
            // 
            this.cmd.AutoSize = true;
            this.cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd.Location = new System.Drawing.Point(276, 238);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(46, 18);
            this.cmd.TabIndex = 1;
            this.cmd.Text = "label1";
            // 
            // CB_Example
            // 
            this.CB_Example.FormattingEnabled = true;
            this.CB_Example.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.CB_Example.Location = new System.Drawing.Point(240, 420);
            this.CB_Example.Name = "CB_Example";
            this.CB_Example.Size = new System.Drawing.Size(132, 21);
            this.CB_Example.TabIndex = 2;
            this.CB_Example.Text = "выбрать пример";
            this.CB_Example.SelectedIndexChanged += new System.EventHandler(this.CB_Example_SelectedIndexChanged);
            // 
            // L_ArrayOfA
            // 
            this.L_ArrayOfA.AutoSize = true;
            this.L_ArrayOfA.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_ArrayOfA.Location = new System.Drawing.Point(291, 9);
            this.L_ArrayOfA.Name = "L_ArrayOfA";
            this.L_ArrayOfA.Size = new System.Drawing.Size(63, 19);
            this.L_ArrayOfA.TabIndex = 3;
            this.L_ArrayOfA.Text = "label1";
            // 
            // CB_Transform
            // 
            this.CB_Transform.FormattingEnabled = true;
            this.CB_Transform.Items.AddRange(new object[] {
            "Поиск циклов через рекурсию",
            "Алгоритм Дейкстры",
            "Алгоритм Краскала",
            "Алгоритм Прима",
            "Полнота"});
            this.CB_Transform.Location = new System.Drawing.Point(378, 420);
            this.CB_Transform.Name = "CB_Transform";
            this.CB_Transform.Size = new System.Drawing.Size(132, 21);
            this.CB_Transform.TabIndex = 5;
            this.CB_Transform.Text = "выбрать преобразование";
            this.CB_Transform.SelectedIndexChanged += new System.EventHandler(this.CB_Transform_SelectedIndexChanged);
            // 
            // B_Transform
            // 
            this.B_Transform.Location = new System.Drawing.Point(378, 447);
            this.B_Transform.Name = "B_Transform";
            this.B_Transform.Size = new System.Drawing.Size(132, 38);
            this.B_Transform.TabIndex = 4;
            this.B_Transform.Text = "вывести";
            this.B_Transform.UseVisualStyleBackColor = true;
            this.B_Transform.Click += new System.EventHandler(this.B_Transform_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 497);
            this.Controls.Add(this.CB_Transform);
            this.Controls.Add(this.B_Transform);
            this.Controls.Add(this.L_ArrayOfA);
            this.Controls.Add(this.CB_Example);
            this.Controls.Add(this.cmd);
            this.Controls.Add(this.B_Out);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Out;
        private System.Windows.Forms.Label cmd;
        private System.Windows.Forms.ComboBox CB_Example;
        private System.Windows.Forms.Label L_ArrayOfA;
        private System.Windows.Forms.ComboBox CB_Transform;
        private System.Windows.Forms.Button B_Transform;
    }
}

