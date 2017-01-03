/*
 * Created by SharpDevelop.
 * User: SoporteSEM
 * Date: 21/12/2016
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gateway_SMS
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	

	
	public partial class MainForm : Form
	{

		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			try{
				serialPort1.Close();
				serialPort1.PortName=textBox1.Text;
				serialPort1.Open();
			}
			catch(Exception ex){
				MessageBox.Show("Error de Conexión","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			if (serialPort1.IsOpen){
				label4.Text="CONECTADO";
				panel2.Show();
				if (connectSIM900()){
					panel3.Show();
					button1.Enabled=false;
					textBox1.Enabled=false;
				}

			}
			else
			{
				label4.Text="DESCONECTADO";
				panel2.Hide();
			}
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			try{
				if(serialPort1.IsOpen()){
					serialPort1.Close();
				}
				
			}
			catch (Exception ex){}
		}
		
		public void waitForResult(String response){
			while((receivedBuffer.IndexOf(response)==-1)){}
		}
		
		String sendCommand(String command, int delaySec, String response,String result){
			
			bool OK = false;
			receivedBuffer="";
			

			serialPort1.WriteLine((command+"\r\n"));
			
			var task = Task.Run(() => waitForResult(response));
			if (task.Wait(TimeSpan.FromSeconds(delaySec))){
				OK=true;
			}
			else{
				received = "";
			}
			
			return received;
		}
		
		bool connectSIM900(){
			
			String result = "";
			bool OK1 = true;
			bool OK2 = true;
			
			if (!(sendCommand("ATE0",2,"OK") != "")){
				OK1 = false;
			}
			
			if ((result = sendCommand("AT+CREG?",5,"OK")) != ""){
				if (!((result.IndexOf("0,1")!=-1)||(result.IndexOf("1,1")!=-1))){
					OK1=false;
				}
			}
			else
			{
				OK1=false;
			}

			
			if (!(sendCommand("AT+CPIN?",4,"OK") != "")){
				OK1=false;
			}
			
			
			if (OK1){
				AT_label.Text="SIM900 ONLINE";
			}
			else
			{
				AT_label.Text="SIM900 OFFLINE";
			}
			
			
			if ((result = sendCommand("AT+CGSN",4,"OK")) != ""){
				IMEI_textBox.Text=result.Substring(0,result.Length-3);
				
			}
			else
			{
				IMEI_textBox.Text="IMEI ERROR";
				
			}
			
			if ((result = sendCommand("AT+CSQ",6,"OK")) != ""){
				int i =0;
				
				do{
					i++;
				}while ((result[i] != ':') && ( i<result.Length));
				
				if (Char.IsNumber(result[i+2]) && Char.IsNumber(result[i+3])){
					CSQ_label.Text="SEÑAL:"+result[i+2]+result[i+3];
				}
				else
					if (Char.IsNumber(result[i+2])){
					CSQ_label.Text="SEÑAL:0"+result[i+2];
				}

			}
			else
			{
				CSQ_label.Text="ERROR EN SEÑAL";
				
			}
			
			
			OK2=true;
			
			if (!((sendCommand("AT+CMGF=1",3,"OK")) != "")){
				OK2=false;
			}
			
			if (!((sendCommand("AT+CSCS=\"GSM\"",3,"OK")) != "")){
				OK2=false;
			}
			
			if (OK2){
				SMSReady_label.Text="LISTO PARA ENVIAR SMS";
			}
			else
			{
				SMSReady_label.Text="NO LISTO PARA ENVIAR SMS";
			}
			
			
			
			return (OK1 && OK2);

		}
		
		bool enviarSMS(){
			bool OK=true;
			
			progressBar1.Value=20;
			if (((sendCommand("AT+CMGS=\""+codArea_textbox.Text+numero_textBox.Text+"\"",4,"ERROR")) != "")){
				OK=false;
			}
			progressBar1.Value=50;
			if (((sendCommand(mensaje_textBox.Text,4,"ERROR")) != "")){
				OK=false;
			}
			progressBar1.Value=70;
			if (!((sendCommand("\x1A",3,"OK")) != "")){
				OK=false;
			}
			progressBar1.Value=100;
			return OK;

		}
		void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			receivedBuffer=receivedBuffer+serialPort1.ReadLine();
		}
		
		bool SIM900_getIMEI(string IMEI){
			
			String result = "";
			
			if ((result = sendCommand("AT+CGSN",4,"OK")) != ""){
				IMEI_textBox.Text=result.Substring(0,result.Length-3);
				
			}
			else
			{
				IMEI_textBox.Text="IMEI ERROR";
				
			}
			
		}
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		void EnviarClick(object sender, EventArgs e)
		{
			estadoMensaje_label.Text="ENVIANDO...";
			progressBar1.Visible=true;
			progressBar1.Value=0;
			if(enviarSMS()){
				estadoMensaje_label.Text="MENSAJE ENVIADO";
			}
			else
			{
				estadoMensaje_label.Text="MENSAJE NO ENVIADO";
			}
			
		}
	}
	

	public class SIM900{
		public String receivedBuffer;
		public string IMEI;
		
		
		public SIM900(){
			receivedBuffer="";
			IMEI="";
			
		}
	}
	
}
