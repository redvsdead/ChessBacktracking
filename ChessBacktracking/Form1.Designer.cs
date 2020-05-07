namespace ChessBacktracking
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.boardBefore = new System.Windows.Forms.DataGridView();
            this.queenButton = new System.Windows.Forms.Button();
            this.knightButton = new System.Windows.Forms.Button();
            this.boardAfter = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.boardBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // boardBefore
            // 
            this.boardBefore.AllowUserToAddRows = false;
            this.boardBefore.AllowUserToDeleteRows = false;
            this.boardBefore.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardBefore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardBefore.Location = new System.Drawing.Point(32, 20);
            this.boardBefore.Name = "boardBefore";
            this.boardBefore.RowTemplate.Height = 24;
            this.boardBefore.Size = new System.Drawing.Size(327, 247);
            this.boardBefore.TabIndex = 0;
            // 
            // queenButton
            // 
            this.queenButton.Location = new System.Drawing.Point(386, 20);
            this.queenButton.Name = "queenButton";
            this.queenButton.Size = new System.Drawing.Size(417, 57);
            this.queenButton.TabIndex = 1;
            this.queenButton.Text = "Поставить ферзей";
            this.queenButton.UseVisualStyleBackColor = true;
            this.queenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // knightButton
            // 
            this.knightButton.Location = new System.Drawing.Point(386, 103);
            this.knightButton.Name = "knightButton";
            this.knightButton.Size = new System.Drawing.Size(417, 57);
            this.knightButton.TabIndex = 3;
            this.knightButton.Text = "Поставить коней";
            this.knightButton.UseVisualStyleBackColor = true;
            this.knightButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // boardAfter
            // 
            this.boardAfter.AllowUserToAddRows = false;
            this.boardAfter.AllowUserToDeleteRows = false;
            this.boardAfter.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boardAfter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardAfter.Location = new System.Drawing.Point(32, 322);
            this.boardAfter.Name = "boardAfter";
            this.boardAfter.RowTemplate.Height = 24;
            this.boardAfter.Size = new System.Drawing.Size(327, 247);
            this.boardAfter.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 626);
            this.Controls.Add(this.boardAfter);
            this.Controls.Add(this.knightButton);
            this.Controls.Add(this.queenButton);
            this.Controls.Add(this.boardBefore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boardBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardAfter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        public System.Windows.Forms.DataGridView boardBefore;
        private System.Windows.Forms.Button queenButton;
        private System.Windows.Forms.Button knightButton;
        public System.Windows.Forms.DataGridView boardAfter;
    }
}

