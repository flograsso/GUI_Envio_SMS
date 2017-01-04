/*
 * Created by SharpDevelop.
 * User: SoporteSEM
 * Date: 21/12/2016
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GUI_Envio_SMS
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label AT_label;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox IMEI_textBox;
		private System.Windows.Forms.Label CSQ_label;
		private System.Windows.Forms.Label SMSReady_label;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label estadoMensaje_label;
		private System.Windows.Forms.Button Enviar;
		private System.Windows.Forms.TextBox mensaje_textBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox numero_textBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox codArea_textbox;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.IMEI_textBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SMSReady_label = new System.Windows.Forms.Label();
			this.CSQ_label = new System.Windows.Forms.Label();
			this.AT_label = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.codArea_textbox = new System.Windows.Forms.TextBox();
			this.estadoMensaje_label = new System.Windows.Forms.Label();
			this.Enviar = new System.Windows.Forms.Button();
			this.mensaje_textBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.numero_textBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.IMEI_textBox);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(306, 88);
			this.panel1.TabIndex = 0;
			// 
			// IMEI_textBox
			// 
			this.IMEI_textBox.Location = new System.Drawing.Point(57, 50);
			this.IMEI_textBox.Name = "IMEI_textBox";
			this.IMEI_textBox.ReadOnly = true;
			this.IMEI_textBox.Size = new System.Drawing.Size(122, 20);
			this.IMEI_textBox.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "IMEI:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Conectar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(188, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "DESCONECTADO";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(188, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Estado:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(57, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(41, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "COM5";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Puerto:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Conexion:";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.SMSReady_label);
			this.panel2.Controls.Add(this.CSQ_label);
			this.panel2.Controls.Add(this.AT_label);
			this.panel2.Location = new System.Drawing.Point(13, 107);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(306, 93);
			this.panel2.TabIndex = 1;
			this.panel2.Visible = false;
			// 
			// SMSReady_label
			// 
			this.SMSReady_label.Location = new System.Drawing.Point(0, 65);
			this.SMSReady_label.Name = "SMSReady_label";
			this.SMSReady_label.Size = new System.Drawing.Size(179, 23);
			this.SMSReady_label.TabIndex = 3;
			// 
			// CSQ_label
			// 
			this.CSQ_label.Location = new System.Drawing.Point(0, 42);
			this.CSQ_label.Name = "CSQ_label";
			this.CSQ_label.Size = new System.Drawing.Size(135, 23);
			this.CSQ_label.TabIndex = 2;
			// 
			// AT_label
			// 
			this.AT_label.Location = new System.Drawing.Point(0, 19);
			this.AT_label.Name = "AT_label";
			this.AT_label.Size = new System.Drawing.Size(135, 23);
			this.AT_label.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.codArea_textbox);
			this.panel3.Controls.Add(this.estadoMensaje_label);
			this.panel3.Controls.Add(this.Enviar);
			this.panel3.Controls.Add(this.mensaje_textBox);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.numero_textBox);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Location = new System.Drawing.Point(326, 13);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(295, 187);
			this.panel3.TabIndex = 2;
			this.panel3.Visible = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(130, 52);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(19, 23);
			this.label10.TabIndex = 10;
			this.label10.Text = "15";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(78, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 23);
			this.label9.TabIndex = 9;
			this.label9.Text = "0";
			// 
			// codArea_textbox
			// 
			this.codArea_textbox.Location = new System.Drawing.Point(90, 49);
			this.codArea_textbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.codArea_textbox.Name = "codArea_textbox";
			this.codArea_textbox.Size = new System.Drawing.Size(34, 20);
			this.codArea_textbox.TabIndex = 8;
			// 
			// estadoMensaje_label
			// 
			this.estadoMensaje_label.AutoSize = true;
			this.estadoMensaje_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.estadoMensaje_label.Location = new System.Drawing.Point(78, 144);
			this.estadoMensaje_label.Name = "estadoMensaje_label";
			this.estadoMensaje_label.Size = new System.Drawing.Size(0, 13);
			this.estadoMensaje_label.TabIndex = 7;
			// 
			// Enviar
			// 
			this.Enviar.Location = new System.Drawing.Point(111, 113);
			this.Enviar.Name = "Enviar";
			this.Enviar.Size = new System.Drawing.Size(75, 23);
			this.Enviar.TabIndex = 6;
			this.Enviar.Text = "Enviar";
			this.Enviar.UseVisualStyleBackColor = true;
			this.Enviar.Click += new System.EventHandler(this.EnviarClick);
			// 
			// mensaje_textBox
			// 
			this.mensaje_textBox.Location = new System.Drawing.Point(78, 78);
			this.mensaje_textBox.Name = "mensaje_textBox";
			this.mensaje_textBox.Size = new System.Drawing.Size(168, 20);
			this.mensaje_textBox.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(12, 82);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "MENSAJE:";
			// 
			// numero_textBox
			// 
			this.numero_textBox.Location = new System.Drawing.Point(152, 49);
			this.numero_textBox.Name = "numero_textBox";
			this.numero_textBox.Size = new System.Drawing.Size(91, 20);
			this.numero_textBox.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(12, 53);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "NÚMERO:";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(4, 3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "ENVÍO SMS";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(627, 208);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "GUI_Envio_SMS";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
