using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_CS_SQL_SERVER
{
    class ConexaoModbus
    {
        public float[] dados = new float[11]; // Valor dos dados coletados do CLP
        const float cem = 100;
        public ConexaoModbus()
        {                        
        }
        public float[] Conectar(string IP)
        {
            try
            {
                ModbusClient Conexao = new ModbusClient(IP, 502);    //Ip-Address and Port of Modbus-TCP-Server
                Conexao.Connect();         //Connect to Server
                int[] valores = Conexao.ReadHoldingRegisters(300, 52);
                int[] alertas = Conexao.ReadInputRegisters(0, 16);
                dados[0] = 1; // se conectado
                dados[1] = alertas[15]; // dado giroflex
                dados[2] = alertas[14]; // dado sirene
                dados[3] = valores[20]; // dado Autonomia
                dados[4] = valores[50] / cem; // dado tensão da bateria
                dados[5] = valores[0] / cem; // dado tensão da placa solar
                dados[6] = valores[13] / cem; // dado corrente estação
                dados[7] = valores[16] / cem; // dado temperatura estacao
                dados[8] = valores[17] / cem; // dado temperaturada controlador de carga
               
            }
            catch
            {
                dados[0] = 0;
            }
            return dados;
        }
    }
}
