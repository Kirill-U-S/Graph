
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
            this.CB_Scale = new System.Windows.Forms.ComboBox();
            this.B_Delete = new System.Windows.Forms.Button();
            this.B_SetScale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Out
            // 
            this.B_Out.Location = new System.Drawing.Point(99, 511);
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
            this.cmd.Location = new System.Drawing.Point(12, 179);
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
            this.CB_Example.Location = new System.Drawing.Point(99, 484);
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
            this.L_ArrayOfA.Location = new System.Drawing.Point(170, 9);
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
            this.CB_Transform.Location = new System.Drawing.Point(237, 484);
            this.CB_Transform.Name = "CB_Transform";
            this.CB_Transform.Size = new System.Drawing.Size(132, 21);
            this.CB_Transform.TabIndex = 5;
            this.CB_Transform.Text = "выбрать преобразование";
            this.CB_Transform.SelectedIndexChanged += new System.EventHandler(this.CB_Transform_SelectedIndexChanged);
            // 
            // B_Transform
            // 
            this.B_Transform.Location = new System.Drawing.Point(237, 511);
            this.B_Transform.Name = "B_Transform";
            this.B_Transform.Size = new System.Drawing.Size(132, 38);
            this.B_Transform.TabIndex = 4;
            this.B_Transform.Text = "вывести";
            this.B_Transform.UseVisualStyleBackColor = true;
            this.B_Transform.Click += new System.EventHandler(this.B_Transform_Click);
            // 
            // CB_Scale
            // 
            this.CB_Scale.FormattingEnabled = true;
            this.CB_Scale.Location = new System.Drawing.Point(389, 484);
            this.CB_Scale.Name = "CB_Scale";
            this.CB_Scale.Size = new System.Drawing.Size(38, 21);
            this.CB_Scale.TabIndex = 6;
            this.CB_Scale.Text = "2";
            // 
            // B_Delete
            // 
            this.B_Delete.BackgroundImage = global::Graph.Properties.Resources.otmena;
            this.B_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Delete.Location = new System.Drawing.Point(433, 511);
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(38, 38);
            this.B_Delete.TabIndex = 8;
            this.B_Delete.UseVisualStyleBackColor = true;
            this.B_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // B_SetScale
            // 
            this.B_SetScale.BackColor = System.Drawing.Color.White;
            this.B_SetScale.BackgroundImage = global::Graph.Properties.Resources.galochbka;
            this.B_SetScale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_SetScale.Image = global::Graph.Properties.Resources.galochbka;
            this.B_SetScale.Location = new System.Drawing.Point(389, 511);
            this.B_SetScale.Name = "B_SetScale";
            this.B_SetScale.Size = new System.Drawing.Size(38, 38);
            this.B_SetScale.TabIndex = 7;
            this.B_SetScale.UseVisualStyleBackColor = false;
            this.B_SetScale.Click += new System.EventHandler(this.B_SetScale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.B_Delete);
            this.Controls.Add(this.B_SetScale);
            this.Controls.Add(this.CB_Scale);
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
        private System.Windows.Forms.ComboBox CB_Scale;
        private System.Windows.Forms.Button B_SetScale;
        private System.Windows.Forms.Button B_Delete;
    }
}

