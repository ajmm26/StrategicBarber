using StrategicBarber.DataBase;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StrategicBarber.Clases
{
    public class Licencia
    {


        public string GetCodeLicence()
        {

            DataBaseNegocio dbNeg = new DataBaseNegocio();
            return dbNeg.getCodeMembresy();

        }


        private static readonly string ClavePublicaXML = Environment.GetEnvironmentVariable("clave_publica");

        public static int ValidarLicencia(string codigoBase64)
        {
            if (string.IsNullOrWhiteSpace(codigoBase64))
            {
                return -1;
            }

            try
            {
                // 1. Convertimos el texto raro de la BD a bytes manejables
                byte[] paqueteCompleto = Convert.FromBase64String(codigoBase64);

                // 2. Desempaquetamos el bloque (Separamos la firma del texto de la licencia)
                int tamanoFirma = BitConverter.ToInt32(paqueteCompleto, 0);
                byte[] firma = new byte[tamanoFirma];
                byte[] datosBytes = new byte[paqueteCompleto.Length - 4 - tamanoFirma];

                Buffer.BlockCopy(paqueteCompleto, 4, firma, 0, tamanoFirma);
                Buffer.BlockCopy(paqueteCompleto, 4 + tamanoFirma, datosBytes, 0, datosBytes.Length);

                // 3. Inicializamos el lector criptográfico con tu Clave Pública
                using (RSA rsa = RSA.Create())
                {
                    rsa.FromXmlString(ClavePublicaXML);

                    // 4. VERIFICACIÓN MATEMÁTICA: ¿Este código fue firmado con mi llave privada?
                    bool esAutentico = rsa.VerifyData(datosBytes, firma, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    if (!esAutentico)
                    {
                        MessageBox.Show("¡ALERTA!: El código de activación es falso o fue manipulado.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return 0;
                    }

                    // 5. Si es auténtico, leemos lo que dice adentro de forma segura
                    string textoLicencia = Encoding.UTF8.GetString(datosBytes);

                    // El texto es: "CLIENTE:Alejandro Maza;EXPIRACION:2027-12-31"
                    // Vamos a extraer la fecha de expiración
                    string[] partes = textoLicencia.Split(':');
                    string fechaStr = partes[1]; // Corta para obtener "2027-12-31"

                    DateTime fechaExpiracion = DateTime.Parse(fechaStr);

                    // 6. Comprobamos si ya se pasó de la fecha
                    if (DateTime.Now > fechaExpiracion)
                    {
                        MessageBox.Show($"La licencia expiró.\n" + "Contacte a su proveedor de servicios para renovarla","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return 0;
                    }

                    // Si llegó hasta aquí, todo está perfecto
                    MessageBox.Show($"Licencia válida hasta: {fechaStr}","EXITO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al validar el código: {ex.Message}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }

    }
}
