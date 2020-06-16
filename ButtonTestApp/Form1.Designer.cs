﻿namespace ButtonTestApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnFlat = new System.Windows.Forms.Button();
            this.BtnStandard = new System.Windows.Forms.Button();
            this.BtnSystem = new System.Windows.Forms.Button();
            this.BtnPopup = new System.Windows.Forms.Button();
            this.LabelButtonStyle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnFlat
            // 
            this.BtnFlat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnFlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFlat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BtnFlat.Location = new System.Drawing.Point(121, 84);
            this.BtnFlat.Name = "BtnFlat";
            this.BtnFlat.Size = new System.Drawing.Size(207, 74);
            this.BtnFlat.TabIndex = 0;
            this.BtnFlat.Text = "Flat";
            this.BtnFlat.UseVisualStyleBackColor = false;
            this.BtnFlat.Click += new System.EventHandler(this.BtnFlat_Click);
            // 
            // BtnStandard
            // 
            this.BtnStandard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnStandard.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BtnStandard.Location = new System.Drawing.Point(121, 164);
            this.BtnStandard.Name = "BtnStandard";
            this.BtnStandard.Size = new System.Drawing.Size(207, 74);
            this.BtnStandard.TabIndex = 0;
            this.BtnStandard.Text = "Standard";
            this.BtnStandard.UseVisualStyleBackColor = false;
            this.BtnStandard.Click += new System.EventHandler(this.BtnStandard_Click);
            // 
            // BtnSystem
            // 
            this.BtnSystem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnSystem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnSystem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BtnSystem.Location = new System.Drawing.Point(334, 164);
            this.BtnSystem.Name = "BtnSystem";
            this.BtnSystem.Size = new System.Drawing.Size(207, 74);
            this.BtnSystem.TabIndex = 0;
            this.BtnSystem.Text = "System";
            this.BtnSystem.UseVisualStyleBackColor = false;
            this.BtnSystem.Click += new System.EventHandler(this.BtnSystem_Click);
            // 
            // BtnPopup
            // 
            this.BtnPopup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnPopup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPopup.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BtnPopup.Location = new System.Drawing.Point(334, 84);
            this.BtnPopup.Name = "BtnPopup";
            this.BtnPopup.Size = new System.Drawing.Size(207, 74);
            this.BtnPopup.TabIndex = 0;
            this.BtnPopup.Text = "Popup";
            this.BtnPopup.UseVisualStyleBackColor = false;
            this.BtnPopup.Click += new System.EventHandler(this.BtnPopup_Click);
            // 
            // LabelButtonStyle
            // 
            this.LabelButtonStyle.AutoSize = true;
            this.LabelButtonStyle.Location = new System.Drawing.Point(60, 363);
            this.LabelButtonStyle.Name = "LabelButtonStyle";
            this.LabelButtonStyle.Size = new System.Drawing.Size(45, 15);
            this.LabelButtonStyle.TabIndex = 1;
            this.LabelButtonStyle.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelButtonStyle);
            this.Controls.Add(this.BtnPopup);
            this.Controls.Add(this.BtnSystem);
            this.Controls.Add(this.BtnStandard);
            this.Controls.Add(this.BtnFlat);
            this.Name = "MainForm";
            this.Text = "Button";
            this.Load += new System.EventHandler(this.Button_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFlat;
        private System.Windows.Forms.Button BtnStandard;
        private System.Windows.Forms.Button BtnSystem;
        private System.Windows.Forms.Button BtnPopup;
        private System.Windows.Forms.Label LabelButtonStyle;
    }
}

