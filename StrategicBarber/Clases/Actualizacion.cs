using System;
using System.Collections.Generic;
using System.Text;
using Velopack;
using Velopack.Sources;
using static System.Net.WebRequestMethods;


namespace StrategicBarber.Clases
{
    public class Actualizacion
    {
        UpdateManager updt;
        UpdateInfo newVersion;
        const string urlGithub = "https://github.com/ajmm26/StrategicBarber";


        public async Task<int> CheckForUpdatesAsync()
        {
            try
            {
                // Configura Velopack para que busque en los Releases de tu GitHub
                // Reemplaza con tu usuario/organización y el nombre de tu repositorio
                var source = new GithubSource(urlGithub, null,false);

                updt = new UpdateManager(source);

                // Buscar actualizaciones
                newVersion = await updt.CheckForUpdatesAsync();

                if (newVersion == null) {

                    return 0;
                }

                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
          
        }


        public async Task chargeAct(int r) {

            if (r == 1) { 
            await updt.DownloadUpdatesAsync(newVersion);

          
            updt.ApplyUpdatesAndRestart(newVersion);
            }

        }


        public int QuestionAct(int q) {

                int res = 0;
            if (q == 1) {

                DialogResult r = MessageBox.Show("Actualizacion disponible, desea actualizar la aplicacion?", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes) {
                    return 1;
                }
              return res;
            }

            return res;
        }

    }
}
