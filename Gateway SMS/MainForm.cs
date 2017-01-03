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
using System.IO.Ports;
using MySql.Data.MySqlClient;

namespace Gateway_SMS
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	

	
	public partial class MainForm : Form
	{

		SIM900 sim900;
		SerialPort serialPort1;
		
		
		
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

		void Button1Click(object sender, EventArgs e)
		{
			bool OK= true;
			
			label4.Text="CONECTANDO...";
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
				
				if(sim900.connectSIM900()){
					AT_label.Text="SIM900 ONLINE";
				}
				else
				{
					AT_label.Text="SIM900 OFFLINE";
					OK=false;
				}
				
				if(sim900.setIMEI()){
					IMEI_textBox.Text=sim900.getIMEI();
				}
				else
				{
					IMEI_textBox.Text="IMEI ERROR";
					OK=false;
				}
				
				if (sim900.setSignal()){
					CSQ_label.Text="SEÑAL:"+sim900.getSignal();
				}
				else
				{
					CSQ_label.Text="ERROR EN SEÑAL";
					OK=false;
				}
				if (sim900.prepareSMS()){
					SMSReady_label.Text="LISTO PARA ENVIAR SMS";
				}
				else
				{
					SMSReady_label.Text="NO LISTO PARA ENVIAR SMS";
					OK=false;
				}

				if(OK){
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

		

		void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			sim900.setReceivedBuffer(sim900.getReceivedBuffer()+serialPort1.ReadLine());
		}
		


		void EnviarClick(object sender, EventArgs e)
		{
			estadoMensaje_label.Text="ENVIANDO...";

			if(sim900.enviarSMS(codArea_textbox.Text+numero_textBox.Text,mensaje_textBox.Text)){
				estadoMensaje_label.Text="MENSAJE ENVIADO";
			}
			else
			{
				estadoMensaje_label.Text="MENSAJE NO ENVIADO";
			}
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			serialPort1 = new SerialPort();
			sim900 = new SIM900(ref serialPort1);
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
			
			
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			try{
				if(serialPort1.IsOpen){
					serialPort1.Close();
				}
				
			}
			catch (Exception ex){}
		}
	}


	public class SIM900{
		
		private String receivedBuffer;
		private string IMEI;
		private string signal;
		private SerialPort serialPort;
		
		public SIM900(ref SerialPort serial){
			receivedBuffer="";
			IMEI="";
			signal = "";
			serialPort=serial;
		}
		
		public String getSignal(){
			return signal;
		}
		
		public String getReceivedBuffer(){
			return receivedBuffer;
		}
		
		public void setReceivedBuffer(String param){
			receivedBuffer=param;
		}
		
		public String getIMEI(){
			return IMEI;
		}
		
		public void waitForResult(String response){
			while((getReceivedBuffer().IndexOf(response)==-1)){}
		}
		
		
		/*Return = null --> Comando falló
		 *Return !=null 	--> Comando OK*/
		String sendCommand(String command, int delaySec, String response){
			
			string received = "";
			receivedBuffer="";
			
			/*Envio Comando*/
			serialPort.WriteLine((command+"\r\n"));
			
			/*Espero hasta que pase el tiempo delaySec o encuentre el string response en la respuesta*/
			var task = Task.Run(() => waitForResult(response));
			if (task.Wait(TimeSpan.FromSeconds(delaySec))){
				/*Encontro string*/
				received=receivedBuffer;
			}
			else
			{
				/*No Encontro string*/
				received = null;
			}
			
			receivedBuffer="";
			return received;
		}
		
		public bool enviarSMS(string numero, string mensaje){
			bool OK=true;
			
			
			if ((sendCommand("AT+CMGS=\""+numero+"\"",4,"ERROR")) != null){
				OK=false;
			}
			
			if ((sendCommand(mensaje,4,"ERROR")) != null){
				OK=false;
			}
			
			if ((sendCommand("\x1A",3,"OK")) == null){
				OK=false;
			}
			
			return OK;

		}
		
		public bool connectSIM900(){
			
			String result = "";
			bool OK = true;
			
			
			if (sendCommand("ATE0",2,"OK")==null){
				OK = false;
			}
			
			if ((result = sendCommand("AT+CREG?",2,"OK")) != null){
				if ((result.IndexOf("0,1")==-1)&&(result.IndexOf("1,1")==-1)){
					OK=false;
				}
			}
			else
			{
				OK=false;
			}

			
			if (sendCommand("AT+CPIN?",2,"OK")==null){
				OK=false;
			}
			
			return OK;
		}
		
		
		public bool setIMEI(){
			
			string result="";
			bool OK = true;
			
			if ((result = sendCommand("AT+CGSN",2,"OK")) != null){
				IMEI=result.Substring(0,result.Length-3);
			}
			else
			{
				OK=false;
			}
			
			return OK;
			
		}

		
		
		public bool setSignal(){
			
			string result = "";
			bool OK = true;
			
			if ((result = sendCommand("AT+CSQ",2,"OK")) != null){
				
				int i =0;
				
				
				do{
					i++;
				}while ((result[i] != ':') && ( i<result.Length));
				
				if (Char.IsNumber(result[i+2]) && Char.IsNumber(result[i+3])){
					signal=(Convert.ToString(result[i+2]))+(Convert.ToString(result[i+3]));

				}
				else
					if (Char.IsNumber(result[i+2])){
					signal="0"+result[i+2];
					
				}

			}
			else
			{
				OK=false;
				
			}
			return OK;
			
		}
		
		public bool prepareSMS(){
			
			bool OK = true;
			
			if ((sendCommand("AT+CMGF=1",2,"OK")) == null){
				OK=false;
			}
			
			if (sendCommand("AT+CSCS=\"GSM\"",2,"OK") == null){
				OK=false;
			}
			
			
			return OK;
			
		}

	}

}
