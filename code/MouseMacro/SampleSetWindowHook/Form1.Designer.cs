namespace SampleSetWindowHook
{
    partial class Form1
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
            this.btnHookTest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCaplock = new System.Windows.Forms.Button();
            this.btnNumLock = new System.Windows.Forms.Button();
            this.btnScrollLock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHookTest
            // 
            this.btnHookTest.Location = new System.Drawing.Point(60, 156);
            this.btnHookTest.Name = "btnHookTest";
            this.btnHookTest.Size = new System.Drawing.Size(141, 66);
            this.btnHookTest.TabIndex = 0;
            this.btnHookTest.Text = "HookTest";
            this.btnHookTest.UseVisualStyleBackColor = true;
            this.btnHookTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 228);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 87);
            this.textBox1.TabIndex = 1;
            // 
            // btnCaplock
            // 
            this.btnCaplock.Location = new System.Drawing.Point(487, 178);
            this.btnCaplock.Name = "btnCaplock";
            this.btnCaplock.Size = new System.Drawing.Size(74, 58);
            this.btnCaplock.TabIndex = 2;
            this.btnCaplock.Text = "Caplock Test";
            this.btnCaplock.UseVisualStyleBackColor = true;
            this.btnCaplock.Click += new System.EventHandler(this.btnCaplock_Click);
            // 
            // btnNumLock
            // 
            this.btnNumLock.Location = new System.Drawing.Point(567, 178);
            this.btnNumLock.Name = "btnNumLock";
            this.btnNumLock.Size = new System.Drawing.Size(74, 58);
            this.btnNumLock.TabIndex = 2;
            this.btnNumLock.Text = "NumLock Test";
            this.btnNumLock.UseVisualStyleBackColor = true;
            this.btnNumLock.Click += new System.EventHandler(this.btnNumLock_Click);
            // 
            // btnScrollLock
            // 
            this.btnScrollLock.Location = new System.Drawing.Point(647, 178);
            this.btnScrollLock.Name = "btnScrollLock";
            this.btnScrollLock.Size = new System.Drawing.Size(74, 58);
            this.btnScrollLock.TabIndex = 2;
            this.btnScrollLock.Text = "ScrollLock Test";
            this.btnScrollLock.UseVisualStyleBackColor = true;
            this.btnScrollLock.Click += new System.EventHandler(this.btnScrollLock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnScrollLock);
            this.Controls.Add(this.btnNumLock);
            this.Controls.Add(this.btnCaplock);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnHookTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHookTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCaplock;
        private System.Windows.Forms.Button btnNumLock;
        private System.Windows.Forms.Button btnScrollLock;
    }
}

